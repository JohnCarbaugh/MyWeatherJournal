using Microsoft.AspNetCore.WebUtilities;
using MyWeatherJournal.API.Dtos;
using MyWeatherJournal.API.Models;
using System.Text.Json;

namespace MyWeatherJournal.API.Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// Uses the GeoCoding API to get the coordinates of a city by name, then uses the CurrentWeather API to get the current weather for that city.
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Returns the weather details of a single city as a WeatherResult object</returns>
        Task<ApiServiceResult<WeatherResultDto>> GetWeatherByCityAsync(string city, string? state);
    }

    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _currentWeatherBaseUrl;
        private readonly string _geocodingBaseUrl;

        public WeatherService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            // Refer to README.md for how to set up the configuration file with the OpenWeather API key and base URLs.
            _apiKey = config["OpenWeather:ApiKey"];
            _currentWeatherBaseUrl = config["OpenWeather:CurrentWeatherBaseUrl"];
            _geocodingBaseUrl = config["OpenWeather:GeocodingBaseUrl"];
        }

        public async Task<ApiServiceResult<WeatherResultDto>> GetWeatherByCityAsync(string city, string? state)
        {
            // Use GeoCoding API to get the city coordinates by city name (and possibly state)
            var queryParams = new Dictionary<string, string?>()
            {
                ["q"] = $"{city},US",       // Ex: Tulsa,US (find US cities only)
                ["limit"] = "10",           // Retrieve multiple city matches, so we can filter by state if possible
                ["appid"] = _apiKey         // OpenWeather API key
            };

            var geoUrl = QueryHelpers.AddQueryString($"{_geocodingBaseUrl}/direct", queryParams);
            var geoResponse = await _httpClient.GetAsync(geoUrl);

            if (!geoResponse.IsSuccessStatusCode)
            {
                var errorBody = await geoResponse.Content.ReadAsStringAsync();
                return new ApiServiceResult<WeatherResultDto>
                {
                    ErrorMessage = $"Geocoding API returned {(int)geoResponse.StatusCode} : {errorBody}",
                    StatusCode = (int)geoResponse.StatusCode
                };
            }

            var geoJson = await geoResponse.Content.ReadAsStringAsync();
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // Remember: We configured the request to retrieve only one result (limit=1), but the JSON response is still an array.
            var locationsList = JsonSerializer.Deserialize<List<GeoLocationDto>>(geoJson, serializerOptions);

            GeoLocationDto? location = null;

            if (!String.IsNullOrEmpty(state))
            {
                location = locationsList?.FirstOrDefault(l => string.Equals(l.State, state, StringComparison.OrdinalIgnoreCase));
            }

            location ??= locationsList?.FirstOrDefault();

            if (location == null)
            {
                return new ApiServiceResult<WeatherResultDto>
                {
                    ErrorMessage = $"No coordinates found for city: '{city}'",
                    StatusCode = 404
                };
            }

            // Now we can use the coordinates to get the current weather.

            var weatherUrl = $"{_currentWeatherBaseUrl}/weather?lat={location.Lat}&lon={location.Lon}&appid={_apiKey}&units=imperial";
            var weatherResponse = await _httpClient.GetAsync(weatherUrl);

            if (!weatherResponse.IsSuccessStatusCode) 
            {
                var errorBody = await weatherResponse.Content.ReadAsStringAsync();
                return new ApiServiceResult<WeatherResultDto>
                {
                    ErrorMessage = $"CurrentWeather API returned {(int)weatherResponse.StatusCode}: {errorBody}",
                    StatusCode = (int)weatherResponse.StatusCode
                };
            }

            var weatherJson = await weatherResponse.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(weatherJson))
            {
                return new ApiServiceResult<WeatherResultDto>
                {
                    ErrorMessage = "CurrentWeather API returned an empty response.",
                    StatusCode = 204 // No Content
                };
            }

            using var doc = JsonDocument.Parse(weatherJson);
            var root = doc.RootElement;

            // Compose the flattened WeatherResultDto from the Geo Location and Weather data
            var result = new WeatherResultDto
            {
                City = root.GetProperty("name").GetString() ?? "",
                State = location.State ?? "",
                CountryCode = location.Country ?? "",

                Temperature = root.GetProperty("main").GetProperty("temp").GetSingle(),
                TemperatureFeelsLike = root.GetProperty("main").GetProperty("feels_like").GetSingle(),
                TemperatureMin = root.GetProperty("main").GetProperty("temp_min").GetSingle(),
                TemperatureMax = root.GetProperty("main").GetProperty("temp_max").GetSingle(),

                Humidity = root.GetProperty("main").GetProperty("humidity").GetSingle(),
                Pressure = root.GetProperty("main").GetProperty("pressure").GetSingle(),
                Description = root.GetProperty("weather")[0].GetProperty("description").GetString() ?? "",
                Icon = root.GetProperty("weather")[0].GetProperty("icon").GetString() ?? "",

                WindSpeed = root.GetProperty("wind").GetProperty("speed").GetSingle(),
                WindDegree = root.GetProperty("wind").GetProperty("deg").GetInt32(),

                Latitude = location.Lat,
                Longitude = location.Lon,

                TimestampUtc = root.GetProperty("dt").GetInt64(),
                SunriseUtc = root.GetProperty("sys").GetProperty("sunrise").GetInt64(),
                SunsetUtc = root.GetProperty("sys").GetProperty("sunset").GetInt64(),

                VisibilityMetric = root.GetProperty("visibility").GetInt64()
            };

            return new ApiServiceResult<WeatherResultDto> { Data = result, StatusCode = 200 };
        }
    }
}

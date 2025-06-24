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
        Task<ApiServiceResult<WeatherResult>> GetWeatherByCityAsync(string city);
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

        public async Task<ApiServiceResult<WeatherResult>> GetWeatherByCityAsync(string city)
        {
            // Use GeoCoding API to get the city coordinates by city name.
            // Notice we are specifying a limit of 1 to get only the first result.
            var geoUrl = $"{_geocodingBaseUrl}/direct?q={city}&limit=1&appid={_apiKey}";
            var geoResponse = await _httpClient.GetAsync(geoUrl);

            if (!geoResponse.IsSuccessStatusCode)
            {
                var errorBody = await geoResponse.Content.ReadAsStringAsync();
                return new ApiServiceResult<WeatherResult>
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
            var locationsList = JsonSerializer.Deserialize<List<GeoLocation>>(geoJson, serializerOptions);
            var location = locationsList?.FirstOrDefault();

            if (location == null)
            {
                return new ApiServiceResult<WeatherResult>
                {
                    ErrorMessage = $"No coordinates found for city: '{city}'",
                    StatusCode = 404
                };
            }

            // Now we can use the coordinates to get the current weather.

            var weatherUrl = $"{_currentWeatherBaseUrl}/weather?lat={location.Lat}&lon={location.Lon}&appid={_apiKey}&units=metric";
            var weatherResponse = await _httpClient.GetAsync(weatherUrl);

            if (!weatherResponse.IsSuccessStatusCode) 
            {
                var errorBody = await weatherResponse.Content.ReadAsStringAsync();
                return new ApiServiceResult<WeatherResult>
                {
                    ErrorMessage = $"CurrentWeather API returned {(int)weatherResponse.StatusCode}: {errorBody}",
                    StatusCode = (int)weatherResponse.StatusCode
                };
            }

            var weatherJson = await weatherResponse.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(weatherJson))
            {
                return new ApiServiceResult<WeatherResult>
                {
                    ErrorMessage = "CurrentWeather API returned an empty response.",
                    StatusCode = 204 // No Content
                };
            }

            using var doc = JsonDocument.Parse(weatherJson);
            var root = doc.RootElement;

            // Compose the WeatherResult object from the JSON response.
            var result = new WeatherResult
            {
                CityName = root.GetProperty("name").GetString() ?? "",
                Temperature = root.GetProperty("main").GetProperty("temp").GetSingle(),
                Humidity = root.GetProperty("main").GetProperty("humidity").GetSingle(),
                Description = root.GetProperty("weather")[0].GetProperty("description").GetString() ?? ""
            };

            return new ApiServiceResult<WeatherResult> { Data = result, StatusCode = 200 };
        }
    }
}

namespace MyWeatherJournal.API.Dtos
{
    public class WeatherResultDto
    {
        public string City { get; set; }
        public string? State { get; set; }
        public string? CountryCode { get; set; }

        // Timestamps
        public long TimestampUtc { get; set; }
        public long SunriseUtc { get; set; }
        public long SunsetUtc { get; set; }

        // Temperature (This could be metric or imperial, depending on the API settings)
        public float Temperature { get; set; }
        public float TemperatureFeelsLike { get; set; }
        public float TemperatureMin { get; set; }
        public float TemperatureMax { get; set; }

        // Conditions
        public float Humidity { get; set; }
        public float Pressure { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; } // Weather icon code, e.g., "01d" for clear sky (Ex. https://openweathermap.org/img/wn/01d@2x.png)

        // Wind
        public float WindSpeed { get; set; }
        public int WindDegree { get; set; }

        // Location
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        // Miscellaneous
        public long VisibilityMetric { get; set; }                                  // Distance in meters
        public float VisibilityImperial => (float)(VisibilityMetric / 1609.34f);    // Distance in miles, rounded
    }
}

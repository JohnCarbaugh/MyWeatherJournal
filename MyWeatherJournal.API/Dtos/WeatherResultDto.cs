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
        public string? IconUrl => $"https://openweathermap.org/img/wn/{Icon}@2x.png";

        // Wind
        public float WindSpeed { get; set; }
        public int WindDegree { get; set; }
        public string? WindDescription =>
                WindSpeed switch
                {
                    < 1 => "Calm",
                    < 8 => "Light breeze",
                    < 19 => "Fresh breeze",
                    < 25 => "Strong breeze",
                    < 32 => "Near gale",
                    < 39 => "Gale",
                    < 47 => "Strong Gale",
                    < 55 => "Storm",
                    < 64 => "Violent Storm",
                    _ => "Hurricane"
                };

        public string WindDirection
        {
            get
            {
                if (WindDegree < 0 || WindDegree > 360)
                    return "Unknown";

                // "Divide" the 360 degrees into 16 distinct sections
                // Each slice of the pie would be 22.5 degrees wide
                // 360 (total) / 16 (quantity) = 22.5 degrees
                // We can compose an array to correlate with these sections
                // MathRound takes us to the closest section, which correlates to array index
                string[] directions = new[]
                {
                    "N", "NNE", "NE", "ENE",
                    "E", "ESE", "SE", "SSE",
                    "S", "SSW", "SW", "WSW",
                    "W", "WW", "NW", "NNW"
                };

                // The degree divided by the width of one section, reveals the number of sections roughly
                // % 16 is to say: take the result and divide it by 16. Modulus says, take the remainder.
                // Example: 45 degress / 22.5 = 2. Then 2 cannot be divided by 16, so there is the 2 remaining. 
                // Then we use 2 as our index value to our directions array. 
                int index = (int)Math.Round(WindDegree / 22.5) % 16;
                return directions[index];
            }
        }

        // Location
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        // Miscellaneous
        public long VisibilityMetric { get; set; }                                  // Distance in meters
        public float VisibilityImperial => (float)(VisibilityMetric / 1609.34f);    // Distance in miles, rounded
    }
}

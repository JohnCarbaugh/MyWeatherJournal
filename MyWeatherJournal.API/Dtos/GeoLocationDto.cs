namespace MyWeatherJournal.API.Dtos
{
    public class GeoLocationDto
    {
        /// <summary>
        /// City Name
        /// </summary>
        public string Name { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string Country { get; set; }
        public string? State { get; set; }
    }
}

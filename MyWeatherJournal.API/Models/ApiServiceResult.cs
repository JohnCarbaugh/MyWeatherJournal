namespace MyWeatherJournal.API.Models
{
    /// <summary>
    /// We use this class to handle different API response objects. This provides a generic way to handle
    /// both success and error responses across different API services. (Current Weather, GeoCoding, etc.)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiServiceResult<T>
    {
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public int? StatusCode { get; set; }
        public bool Success => ErrorMessage == null;

    }
}

using Microsoft.AspNetCore.Mvc;
using MyWeatherJournal.API.Services;

namespace MyWeatherJournal.API.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // Remember: The controller route (Weather) is applied here
        // baseUrl/weather?city=...
        [HttpGet]
        public async Task<IActionResult> GetWeatherByCity([FromQuery] string city, string? state)
        {
            // Validations
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest(new { error = "Parameter 'city' is required." });
            }

            // Call the service to get the weather data
            var result = await _weatherService.GetWeatherByCityAsync(city, state);

            // Handle error response
            if (!result.Success)
            {
                return StatusCode(result.StatusCode ?? 500, new { error = result.ErrorMessage, status = result.StatusCode, input = city });
            }

            // Respond successfully with the weather data
            return StatusCode(result.StatusCode ?? 200, result.Data);
        }
    }
}

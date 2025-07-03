using Microsoft.AspNetCore.Mvc;
using MyWeatherJournal.API.Services;

namespace MyWeatherJournal.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CityService _cityService;

        public CustomerController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            throw new Exception("not implemented yet.");
        }

        [HttpGet("{id}/favorite-cities")]
        public async Task<IActionResult> GetFavoriteCitiesByCustomerId(int id)
        {
            // TODO: Validations
            // Check if customer exists

            var result = await _cityService.GetFavoriteCitiesByCustomerIdAsync(id);

            // Handle error response
            if (!result.Success)
            {
                return StatusCode(result.StatusCode ?? 500, new { error = result.ErrorMessage, status = result.StatusCode, input = id });
            }

            return StatusCode(result.StatusCode ?? 200, result.Data);
        }
    }
}

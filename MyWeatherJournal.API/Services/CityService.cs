using MyWeatherJournal.API.Dtos;
using MyWeatherJournal.API.Models;
using MyWeatherJournal.API.Repositories;

namespace MyWeatherJournal.API.Services
{
    public interface ICityService
    {
        /// <summary>
        /// Returns a list of favorite cities by customer id.
        /// </summary>
        /// <returns></returns>
        Task<ApiServiceResult<IEnumerable<City>>> GetFavoriteCitiesByCustomerIdAsync(int id);
    }

    public class CityService : ICityService
    {
        private readonly HttpClient _httpClient;
        private readonly ICityRepository _cityRepository;

        public CityService(
            HttpClient httpClient,
            ICityRepository cityRepository)
        {
            _httpClient = httpClient;
            _cityRepository = cityRepository;
        }

        public async Task<ApiServiceResult<IEnumerable<City>>> GetFavoriteCitiesByCustomerIdAsync(int id)
        {
            var result = await _cityRepository.GetFavoriteCitiesByCustomerIdAsync(id);

            return new ApiServiceResult<IEnumerable<City>> { Data = result, StatusCode = 200 };
        }
    }
}

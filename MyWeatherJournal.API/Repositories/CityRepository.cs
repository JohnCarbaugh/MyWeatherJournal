using Microsoft.EntityFrameworkCore;
using MyWeatherJournal.API.Models;
using MyWeatherJournal.API.Data;

namespace MyWeatherJournal.API.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetFavoriteCitiesByCustomerIdAsync(int customerId);
    }

    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetFavoriteCitiesByCustomerIdAsync(int customerId)
        {
            return await _context.CustomerFavoriteCity
                .Where(cf => cf.CustomerId == customerId)
                .Include(cf => cf.City)
                .Select(cf => cf.City)
                .ToListAsync();
        }
    }
}

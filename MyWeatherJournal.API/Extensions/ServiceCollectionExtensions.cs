using MyWeatherJournal.API.Services;
using MyWeatherJournal.API.Repositories;

namespace MyWeatherJournal.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddHttpClient<WeatherService>();
            services.AddScoped<CityService>();
            services.AddScoped<ICityRepository, CityRepository>();
            // Add more services and repositories as needed...

            return services;
        }
    }
}

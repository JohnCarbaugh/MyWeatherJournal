using MyWeatherJournal.API.Services;

namespace MyWeatherJournal.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddHttpClient<WeatherService>();
            // Add more services here as needed...
            return services;
        }
    }
}

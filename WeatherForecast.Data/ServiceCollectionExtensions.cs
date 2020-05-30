using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherForecast.Data.NewFolder;

namespace WeatherForecast.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddTransient<IUserProvider, UserProvider>();
            return services;
        }
    }
}

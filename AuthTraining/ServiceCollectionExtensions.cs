using AuthTraining.Services;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Data;

namespace AuthTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthTraining(this IServiceCollection services)
        {
            services.AddTransient<IIdentityProvider, IdentityProvider>();
            services.AddTransient<IAuthenticationTokenProvider, JwtTokenProvider>();
            services.AddData();
            return services;
        }
    }
}

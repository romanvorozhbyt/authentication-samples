using AuthTraining.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Data;
using WeatherForecastApi.Models;

namespace WeatherForecastApi.Extensions
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

        public static IServiceCollection AddBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = configuration[ApplicationSettingsConstants.JwtIssuer],
                   ValidAudience = configuration[ApplicationSettingsConstants.JwtAudience],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[ApplicationSettingsConstants.JwtSecretKey]))
               };
               options.Events = new JwtBearerEvents
               {
                   OnAuthenticationFailed = context =>
                   {
                       if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                       {
                           context.Response.Headers.Add("Token-Expired", "true");
                       }
                       return Task.CompletedTask;
                   }
               };
           });
            return services;
        }

        public static IServiceCollection AddSwaggerBearerAuthentication(this IServiceCollection services)
        {
            services.AddSwaggerDocument(document =>
            {
                document.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
            return services;
        }
    }
}

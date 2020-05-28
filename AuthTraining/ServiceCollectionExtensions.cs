using AuthTraining.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthTraining(this IServiceCollection services)
        {
            services.AddTransient<IIdentityProvider, IdentityProvider>();
            services.AddTransient<IAuthenticationTokenProvider, JwtTokenProvider>();
            return services;
        }
    }
}

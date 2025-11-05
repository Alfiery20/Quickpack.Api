using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Common.Interface;
using Quickpack.Infrastructure.Services;

namespace Quickpack.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<ICryptography, Cryptography>();
            services.AddSingleton<IEmealService, EmealService>();
            return services;
        }
    }
}

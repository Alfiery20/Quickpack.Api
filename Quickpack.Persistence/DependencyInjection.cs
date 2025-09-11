using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Common.Interface;
using Quickpack.Persistence.Database;

namespace Quickpack.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDataBase>(sp => new SqlDataBase(connectionString));

            //services.AddSingleton<IAutenticacionRepository, AutenticacionRepository>();

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Persistence.Database;
using Quickpack.Persistence.Repository;

namespace Quickpack.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDataBase>(sp => new SqlDataBase(connectionString));

            services.AddSingleton<IAutenticacionRepository, AutenticacionRepository>();
            services.AddSingleton<IRolRepository, RolRepository>();
            services.AddSingleton<IEmpleadoRepository, EmpleadoRepository>();
            services.AddSingleton<ITipoProductoRepository, TipoProductoRepository>();

            return services;
        }
    }
}

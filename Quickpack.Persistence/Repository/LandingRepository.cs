using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Categoria.Query.ObtenerCategoriaMenu;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Landing.Query.ObtenerCategoriaMenuLanding;
using Quickpack.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Persistence.Repository
{
    public class LandingRepository : ILandingRepository
    {
        private readonly IDataBase _dataBase;

        public LandingRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<IEnumerable<ObtenerTipoProductoMenuLandingQueryDTO>> ObtenerTipoProductoMenuLanding(ObtenerTipoProductoMenuLandingQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerTipoProductoMenuLandingQueryDTO> response = new();
                DynamicParameters parameters = new DynamicParameters();

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerTipoProductoMenuLanding]",
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.Add(new ObtenerTipoProductoMenuLandingQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                        });
                    }
                }
                return response;
            }
        }
    }
}

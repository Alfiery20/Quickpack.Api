using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Categoria.Query.ObtenerCategoria;
using Quickpack.Application.Categoria.Query.ObtenerCategoriaMenu;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Landing.Query.ObtenerCategoriaMenuLanding;
using Quickpack.Application.Landing.Query.ObtenerTipoProductoLanding;
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
        public async Task<ObtenerTipoProductoLandingQueryDTO> ObtenerTipoProductoLanding(ObtenerTipoProductoLandingQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                ObtenerTipoProductoLandingQueryDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdTipoProducto", query.IdTipoProducto, DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerLandingTipoProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response = new ObtenerTipoProductoLandingQueryDTO()
                        {
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString(),
                            Multimedia = Convert.IsDBNull(reader["MULTIMEDIA"]) ? "" : reader["MULTIMEDIA"].ToString()
                        };
                    }
                }
                return response;
            }
        }
        public async Task<List<CategoriaLanding>> ObtenerTipoProductoTipoProductoLanding(ObtenerTipoProductoLandingQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<CategoriaLanding> response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdTipoProducto", query.IdTipoProducto, DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerLandingTipoProductoCategorias]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.Add(new CategoriaLanding()
                        {
                            IdCategoria = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString(),
                            Multimedia = Convert.IsDBNull(reader["MULTIMEDIA"]) ? "" : reader["MULTIMEDIA"].ToString()
                        });
                    }
                }
                return response;
            }
        }
    }
}

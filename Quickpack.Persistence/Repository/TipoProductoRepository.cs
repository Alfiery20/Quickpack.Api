using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Rol.Command.AgregarRol;
using Quickpack.Application.Rol.Command.EditarEstadoRol;
using Quickpack.Application.Rol.Command.EditarRol;
using Quickpack.Application.Rol.Query.ObtenerRol;
using Quickpack.Application.Rol.Query.VerRol;
using Quickpack.Application.TipoProducto.Command.AgregarTipoProducto;
using Quickpack.Application.TipoProducto.Command.EditarEstadoTipoProducto;
using Quickpack.Application.TipoProducto.Command.EditarTipoProducto;
using Quickpack.Application.TipoProducto.Query.ObtenerTipoProducto;
using Quickpack.Application.TipoProducto.Query.ObtenerTipoProductoMenu;
using Quickpack.Application.TipoProducto.Query.VerTipoProducto;
using Quickpack.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Persistence.Repository
{
    public class TipoProductoRepository : ITipoProductoRepository
    {
        private readonly IDataBase _dataBase;

        public TipoProductoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<ObtenerTipoProductoQueryDTO> ObtenerTipoProducto(ObtenerTipoProductoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<TipoProducto> tipoProducto = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTermino", query.Termino.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pPage", query.Pagina, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pCantidad", query.Cantidad, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@total", 0, DbType.Int32, ParameterDirection.Output);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerTipoProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        tipoProducto.Add(new TipoProducto()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString(),
                        });
                    }
                }
                ObtenerTipoProductoQueryDTO response = new()
                {
                    TipoProducto = tipoProducto,
                    Pagina = query.Pagina,
                    Total = parameters.Get<int>("@total")
                };
                return response;
            }
        }
        public async Task<AgregarTipoProductoCommandDTO> AgregarTipoProducto(AgregarTipoProductoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnombre", command.Nombre.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_RegistrarTipoProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                AgregarTipoProductoCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<EditarTipoProductoCommandDTO> EditarTipoProducto(EditarTipoProductoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidTipoProducto", command.IdTipoProducto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_EditarTipoProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                EditarTipoProductoCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<VerTipoProductoQueryDTO> VerTipoProducto(VerTipoProductoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdTipoProducto", query.IdTipoProducto, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerTipoProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    VerTipoProductoQueryDTO response = new();
                    while (reader.Read())
                    {
                        response = new VerTipoProductoQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                        };
                    }
                    return response;
                }
            }
        }
        public async Task<EditarEstadoTipoProductoCommandDTO> EditarEstadoTipoProducto(EditarEstadoTipoProductoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidTipoProducto", command.IdTipoProducto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_CambiarEstadoTipoProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                EditarEstadoTipoProductoCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<IEnumerable<ObtenerTipoProductoMenuQueryDTO>> ObtenerTipoProductoMenu(ObtenerTipoProductoMenuQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerTipoProductoMenuQueryDTO> response = new();
                DynamicParameters parameters = new DynamicParameters();

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerTipoProductoMenu]",
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.Add(new ObtenerTipoProductoMenuQueryDTO()
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

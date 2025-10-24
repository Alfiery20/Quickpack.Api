using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Categoria.Command.AgregarCategoria;
using Quickpack.Application.Categoria.Command.CambiarEstadoCategoria;
using Quickpack.Application.Categoria.Command.EditarCategoria;
using Quickpack.Application.Categoria.Query.ObtenerCategoria;
using Quickpack.Application.Categoria.Query.VerCategoria;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Producto.Command.AgregarProducto;
using Quickpack.Application.Producto.Command.EditarEstadoProducto;
using Quickpack.Application.Producto.Command.EditarProducto;
using Quickpack.Application.Producto.Query.ObtenerProducto;
using Quickpack.Application.Producto.Query.VerProducto;
using Quickpack.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Persistence.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IDataBase _dataBase;

        public ProductoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<AgregarProductoCommandDTO> AgregarProducto(AgregarProductoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnombre", command.Nombre.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pdescripcion", command.Descripcion.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pidCategoria", command.IdCategoria, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pprecio", command.Precio, DbType.Double, ParameterDirection.Input);
                parameters.Add("@pmultimedia", command.Multimedia, DbType.String, ParameterDirection.Input);
                parameters.Add("@pidUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pfecha", command.Fecha, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_RegistrarProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                AgregarProductoCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<ObtenerProductoQueryDTO> ObtenerProducto(ObtenerProductoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<Producto> producto = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTermino", query.Termino.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pidCategoria", query.IdCategoria, DbType.String, ParameterDirection.Input);
                parameters.Add("@pPage", query.Pagina, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pCantidad", query.Cantidad, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@total", 0, DbType.Int32, ParameterDirection.Output);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        producto.Add(new Producto()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString(),
                            Precio = Convert.IsDBNull(reader["PRECIO"]) ? 0.00 : Convert.ToDouble(reader["PRECIO"].ToString()),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString(),
                            Categoria = Convert.IsDBNull(reader["CATEGORIA"]) ? "" : reader["CATEGORIA"].ToString(),
                            UsuarioCrea = Convert.IsDBNull(reader["USUARIO_CREA"]) ? "" : reader["USUARIO_CREA"].ToString(),
                            FechaCrea = Convert.IsDBNull(reader["FECHA_CREA"]) ? "" : reader["FECHA_CREA"].ToString(),
                            UsuarioModifica = Convert.IsDBNull(reader["USUARIO_ACTUALIZA"]) ? "" : reader["USUARIO_ACTUALIZA"].ToString(),
                            FechaModifica = Convert.IsDBNull(reader["FECHA_ACTUALIZA"]) ? "" : reader["FECHA_ACTUALIZA"].ToString(),
                        });
                    }
                }
                ObtenerProductoQueryDTO response = new()
                {
                    Pagina = query.Pagina,
                    Total = parameters.Get<int>("@total"),
                    Productos = producto
                };
                return response;
            }
        }
        public async Task<EditarEstadoProductoCommandDTO> EditarEstadoProducto(EditarEstadoProductoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("pidProducto", command.IdProducto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_CambiarEstadoProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                EditarEstadoProductoCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<VerProductoQueryDTO> VerProducto(VerProductoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                VerProductoQueryDTO response = new();
                parameters.Add("@pidProducto", query.IdProducto, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response = new VerProductoQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString(),
                            Precio = Convert.IsDBNull(reader["PRECIO"]) ? 0.00 : Convert.ToDouble(reader["PRECIO"].ToString()),
                            Multimedia = Convert.IsDBNull(reader["MULTIMEDIA"]) ? "" : reader["MULTIMEDIA"].ToString(),
                            IdCategoria = Convert.IsDBNull(reader["CATEGORIA"]) ? 0 : Convert.ToInt32(reader["CATEGORIA"].ToString()),
                        };
                    }
                }
                return response;
            }
        }
        public async Task<EditarProductoCommandDTO> EditarProducto(EditarProductoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", command.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pdescripcion", command.Descripcion.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pidCategoria", command.IdCategoria, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pmultimedia", command.Multimedia, DbType.String, ParameterDirection.Input);
                parameters.Add("@pprecio", command.Precio, DbType.Double, ParameterDirection.Input);
                parameters.Add("@pidUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pfecha", command.Fecha, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_EditarProducto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                EditarProductoCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
    }
}

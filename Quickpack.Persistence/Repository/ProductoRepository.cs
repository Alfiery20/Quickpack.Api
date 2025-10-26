using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Categoria.Command.AgregarCategoria;
using Quickpack.Application.Categoria.Command.CambiarEstadoCategoria;
using Quickpack.Application.Categoria.Command.EditarCategoria;
using Quickpack.Application.Categoria.Query.ObtenerCategoria;
using Quickpack.Application.Categoria.Query.VerCategoria;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Producto.Command.AgregarFichaTecnica;
using Quickpack.Application.Producto.Command.AgregarProducto;
using Quickpack.Application.Producto.Command.EditarEstadoProducto;
using Quickpack.Application.Producto.Command.EditarFichaTecnica;
using Quickpack.Application.Producto.Command.EditarProducto;
using Quickpack.Application.Producto.Query.ObtenerProducto;
using Quickpack.Application.Producto.Query.VerFichaTecnica;
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
        public async Task<AgregarFichaTecnicaCommandDTO> AgregarFichaTecnica(AgregarFichaTecnicaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidProducto", command.IdProducto, DbType.Int32, ParameterDirection.Input);

                parameters.Add("@plargoCamara", command.LargoCamara, DbType.Double, ParameterDirection.Input);
                parameters.Add("@panchoCamara", command.AnchoCamara, DbType.Double, ParameterDirection.Input);
                parameters.Add("@paltoCamara", command.AltoCamara, DbType.Double, ParameterDirection.Input);

                parameters.Add("@plargoMaquina", command.LargoMaquina, DbType.Double, ParameterDirection.Input);
                parameters.Add("@panchoMaquina", command.AnchoMaquina, DbType.Double, ParameterDirection.Input);
                parameters.Add("@paltoMaquina", command.AltoMaquina, DbType.Double, ParameterDirection.Input);

                parameters.Add("@pbarraSellado", command.BarraSellado, DbType.Double, ParameterDirection.Input);
                parameters.Add("@pcapacidadBomba", command.CapacidadBomba, DbType.Double, ParameterDirection.Input);
                parameters.Add("@pcicloInferior", command.CicloInferior, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pcicloSuperior", command.CicloSuperior, DbType.Int32, ParameterDirection.Input);

                parameters.Add("@ppeso", command.Peso, DbType.Double, ParameterDirection.Input);
                parameters.Add("@ppotencia", command.Potencia, DbType.Double, ParameterDirection.Input);

                parameters.Add("@pplacaInsercion", command.PlacaInsercion, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@psistemaControl", command.SistemaControl, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdeteccionVacioFinal", command.DeteccionVacioFinal, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdeteccionCarne", command.DeteccionCarne, DbType.String, ParameterDirection.Input);
                parameters.Add("@psoftAir", command.SoftAir, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcontrolLiquidos", command.ControlLiquidos, DbType.String, ParameterDirection.Input);

                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_RegistrarFichaTecnica]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                AgregarFichaTecnicaCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<EditarFichaTecnicaCommandDTO> EditarFichaTecnica(EditarFichaTecnicaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidProducto", command.IdProducto, DbType.Int32, ParameterDirection.Input);

                parameters.Add("@plargoCamara", command.LargoCamara, DbType.Double, ParameterDirection.Input);
                parameters.Add("@panchoCamara", command.AnchoCamara, DbType.Double, ParameterDirection.Input);
                parameters.Add("@paltoCamara", command.AltoCamara, DbType.Double, ParameterDirection.Input);

                parameters.Add("@plargoMaquina", command.LargoMaquina, DbType.Double, ParameterDirection.Input);
                parameters.Add("@panchoMaquina", command.AnchoMaquina, DbType.Double, ParameterDirection.Input);
                parameters.Add("@paltoMaquina", command.AltoMaquina, DbType.Double, ParameterDirection.Input);

                parameters.Add("@pbarraSellado", command.BarraSellado, DbType.Double, ParameterDirection.Input);
                parameters.Add("@pcapacidadBomba", command.CapacidadBomba, DbType.Double, ParameterDirection.Input);
                parameters.Add("@pcicloInferior", command.CicloInferior, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pcicloSuperior", command.CicloSuperior, DbType.Int32, ParameterDirection.Input);

                parameters.Add("@ppeso", command.Peso, DbType.Double, ParameterDirection.Input);
                parameters.Add("@ppotencia", command.Potencia, DbType.Double, ParameterDirection.Input);

                parameters.Add("@pplacaInsercion", command.PlacaInsercion, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@psistemaControl", command.SistemaControl, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdeteccionVacioFinal", command.DeteccionVacioFinal, DbType.String, ParameterDirection.Input);
                parameters.Add("@pdeteccionCarne", command.DeteccionCarne, DbType.String, ParameterDirection.Input);
                parameters.Add("@psoftAir", command.SoftAir, DbType.String, ParameterDirection.Input);
                parameters.Add("@pcontrolLiquidos", command.ControlLiquidos, DbType.String, ParameterDirection.Input);

                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_EditarFichaTecnica]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                EditarFichaTecnicaCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<VerFichaTecnicaQueryDTO> VerFichaTecnica(VerFichaTecnicaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                VerFichaTecnicaQueryDTO response = new();
                parameters.Add("@pidProducto", query.IdProducto, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerFichaTecnica]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response = new VerFichaTecnicaQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            LargoCamara = Convert.IsDBNull(reader["LARGO_CAMARA"]) ? 0.00 : Convert.ToDouble(reader["LARGO_CAMARA"].ToString()),
                            AnchoCamara = Convert.IsDBNull(reader["ANCHO_CAMARA"]) ? 0.00 : Convert.ToDouble(reader["ANCHO_CAMARA"].ToString()),
                            AltoCamara = Convert.IsDBNull(reader["ALTO_CAMARA"]) ? 0.00 : Convert.ToDouble(reader["ALTO_CAMARA"].ToString()),

                            LargoMaquina = Convert.IsDBNull(reader["LARGO_MAQUINA"]) ? 0.00 : Convert.ToDouble(reader["LARGO_MAQUINA"].ToString()),
                            AnchoMaquina = Convert.IsDBNull(reader["ANCHO_MAQUINA"]) ? 0.00 : Convert.ToDouble(reader["ANCHO_MAQUINA"].ToString()),
                            AltoMaquina = Convert.IsDBNull(reader["ALTO_MAQUINA"]) ? 0.00 : Convert.ToDouble(reader["ALTO_MAQUINA"].ToString()),

                            BarraSellado = Convert.IsDBNull(reader["BARRA_SELLADO"]) ? 0.00 : Convert.ToDouble(reader["BARRA_SELLADO"].ToString()),
                            CapacidadBomba = Convert.IsDBNull(reader["CAPACIDAD_BOMBA"]) ? 0.00 : Convert.ToDouble(reader["CAPACIDAD_BOMBA"].ToString()),
                            CicloInferior = Convert.IsDBNull(reader["CICLO_INFERIOR"]) ? 0 : Convert.ToInt32(reader["CICLO_INFERIOR"].ToString()),
                            CicloSuperior = Convert.IsDBNull(reader["CICLO_SUPERIOR"]) ? 0 : Convert.ToInt32(reader["CICLO_SUPERIOR"].ToString()),

                            Peso = Convert.IsDBNull(reader["PESO"]) ? 0.00 : Convert.ToDouble(reader["PESO"].ToString()),
                            Potencia = Convert.IsDBNull(reader["POTENCIA"]) ? 0.00 : Convert.ToDouble(reader["POTENCIA"].ToString()),
                            
                            PlacaInsercion = Convert.IsDBNull(reader["PLACA_INSERCION"]) ? 0 : Convert.ToInt32(reader["PLACA_INSERCION"].ToString()),
                            SistemaControl = Convert.IsDBNull(reader["SISTEMA_CONTROL"]) ? "" : reader["SISTEMA_CONTROL"].ToString(),
                            DeteccionVacioFinal = Convert.IsDBNull(reader["DETECCION_VACIO_FINAL"]) ? "" : reader["DETECCION_VACIO_FINAL"].ToString(),
                            DeteccionCarne = Convert.IsDBNull(reader["DETECCION_CARNE"]) ? "" : reader["DETECCION_CARNE"].ToString(),
                            SoftAir = Convert.IsDBNull(reader["SOFTAIR"]) ? "" : reader["SOFTAIR"].ToString(),
                            ControlLiquidos = Convert.IsDBNull(reader["CONTROL_LIQUIDOS"]) ? "" : reader["CONTROL_LIQUIDOS"].ToString()
                        };
                    }
                }
                return response;
            }
        }
    }
}

using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Categoria.Query.ObtenerCategoria;
using Quickpack.Application.Categoria.Query.ObtenerCategoriaMenu;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Landing.Query.ObtenerCategoriaLanding;
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
        public async Task<List<CategoriaLanding>> ObtenerTipoProductoCategoriaLanding(ObtenerTipoProductoLandingQuery query)
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
        public async Task<ObtenerCategoriaLandingQueryDTO> ObtenerCategoriaLanding(ObtenerCategoriaLandingQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                ObtenerCategoriaLandingQueryDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdTipoProducto", query.IdTipoProducto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pIdCategoria", query.IdCategoria, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerLandingCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response = new ObtenerCategoriaLandingQueryDTO()
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
        public async Task<List<ProductoLanding>> ObtenerCategoriaProductoLanding(ObtenerCategoriaLandingQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ProductoLanding> response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdCategoria", query.IdCategoria, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerLandingCategoriaProductos]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.Add(new ProductoLanding()
                        {
                            IdProducto = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString(),
                            Multimedia = Convert.IsDBNull(reader["MULTIMEDIA"]) ? "" : reader["MULTIMEDIA"].ToString(),
                            Precio = Convert.IsDBNull(reader["PRECIO"]) ? 0.00 : Convert.ToDouble(reader["PRECIO"].ToString()),
                        });
                    }
                }
                return response;
            }
        }
        public async Task<BeneficioCategoriaLanding> ObtenerBeneficioCategoriaLanding(ObtenerCategoriaLandingQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<BeneficioLanding> beneficios = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdCategoria", query.IdCategoria, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@descripcion", "", DbType.String, ParameterDirection.Output);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerBeneficioCategoriaLanding]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        beneficios.Add(new BeneficioLanding()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString()
                        });
                    }
                }
                BeneficioCategoriaLanding response = new()
                {
                    Descripcion = parameters.Get<string>("@descripcion"),
                    Beneficios = beneficios,
                };
                return response;
            }
        }
        public async Task<List<CaracteristicaLanding>> ObtenerCaracteristicaLanding(ObtenerCategoriaLandingQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<CaracteristicaLanding> response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdCategoria", query.IdCategoria, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerCaracteristicaCategoriaLanding]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.Add(new CaracteristicaLanding()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString(),
                            Multimedia = Convert.IsDBNull(reader["MULTIMEDIA"]) ? "" : reader["MULTIMEDIA"].ToString(),
                        });
                    }
                }
                return response;
            }
        }
        public async Task<List<FichaTecnicaLanding>> ObtenerFichaTecnicaLanding(ObtenerCategoriaLandingQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<FichaTecnicaLanding> response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdCategoria", query.IdCategoria, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerFichaTecnicaProductoLanding]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.Add(new FichaTecnicaLanding()
                        {
                            IdProducto = Convert.IsDBNull(reader["ID_PRODUCTO"]) ? 0 : Convert.ToInt32(reader["ID_PRODUCTO"].ToString()),
                            NombreProducto = Convert.IsDBNull(reader["NOMBRE_PRODUCTO"]) ? "" : reader["NOMBRE_PRODUCTO"].ToString(),

                            AltoCamara = Convert.IsDBNull(reader["ALTO_CAMARA"]) ? 0.00 : Convert.ToDouble(reader["ALTO_CAMARA"].ToString()),
                            AnchoCamara = Convert.IsDBNull(reader["ANCHO_CAMARA"]) ? 0.00 : Convert.ToDouble(reader["ANCHO_CAMARA"].ToString()),
                            LargoCamara = Convert.IsDBNull(reader["LARGO_CAMARA"]) ? 0.00 : Convert.ToDouble(reader["LARGO_CAMARA"].ToString()),

                            AltoMaquina = Convert.IsDBNull(reader["ALTO_MAQUINA"]) ? 0.00 : Convert.ToDouble(reader["ALTO_MAQUINA"].ToString()),
                            AnchoMaquina = Convert.IsDBNull(reader["ANCHO_MAQUINA"]) ? 0.00 : Convert.ToDouble(reader["ANCHO_MAQUINA"].ToString()),
                            LargoMaquina = Convert.IsDBNull(reader["LARGO_MAQUINA"]) ? 0.00 : Convert.ToDouble(reader["LARGO_MAQUINA"].ToString()),

                            BarraSellado = Convert.IsDBNull(reader["BARRA_SELLADO"]) ? 0.00 : Convert.ToDouble(reader["BARRA_SELLADO"].ToString()),
                            CapacidadBomba = Convert.IsDBNull(reader["CAPACIDAD_BOMBA"]) ? 0 : Convert.ToInt32(reader["CAPACIDAD_BOMBA"].ToString()),

                            CicloSuperior = Convert.IsDBNull(reader["CICLO_SUPERIOR"]) ? 0 : Convert.ToInt32(reader["CICLO_SUPERIOR"].ToString()),
                            CicloInferior = Convert.IsDBNull(reader["CICLO_INFERIOR"]) ? 0 : Convert.ToInt32(reader["CICLO_INFERIOR"].ToString()),

                            Peso = Convert.IsDBNull(reader["PESO"]) ? 0.00 : Convert.ToDouble(reader["PESO"].ToString()),

                            PlacaInsercion = Convert.IsDBNull(reader["PLACA_INSERCION"]) ? 0 : Convert.ToInt32(reader["PLACA_INSERCION"].ToString()),
                            SistemaControl = Convert.IsDBNull(reader["SISTEMA_CONTROL"]) ? "" : reader["SISTEMA_CONTROL"].ToString(),

                            DeteccionVacioFinal = Convert.IsDBNull(reader["DETECCION_VACION_FINAL"]) ? "" : reader["DETECCION_VACION_FINAL"].ToString(),
                            DeteccionCarne = Convert.IsDBNull(reader["DETECCION_CARNE"]) ? "" : reader["DETECCION_CARNE"].ToString(),

                            SoftAir = Convert.IsDBNull(reader["SOFTAIR"]) ? "" : reader["SOFTAIR"].ToString(),
                            ControlLiquidos = Convert.IsDBNull(reader["CONTROL_LIQUIDOS"]) ? "" : reader["CONTROL_LIQUIDOS"].ToString(),

                            Potencia = Convert.IsDBNull(reader["POTENCIA"]) ? 0.00 : Convert.ToDouble(reader["POTENCIA"].ToString()),
                        });
                    }
                }
                return response;
            }
        }
    }
}

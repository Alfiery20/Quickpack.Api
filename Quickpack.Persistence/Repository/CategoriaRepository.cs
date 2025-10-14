using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Categoria.Command.AgregarBeneficios;
using Quickpack.Application.Categoria.Command.AgregarCategoria;
using Quickpack.Application.Categoria.Command.CambiarEstadoCategoria;
using Quickpack.Application.Categoria.Command.EditarCategoria;
using Quickpack.Application.Categoria.Query.ObtenerBeneficio;
using Quickpack.Application.Categoria.Query.ObtenerCategoria;
using Quickpack.Application.Categoria.Query.ObtenerCategoriaMenu;
using Quickpack.Application.Categoria.Query.VerCategoria;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Persistence.Database;
using System.Data;
using System.Xml.Serialization;

namespace Quickpack.Persistence.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IDataBase _dataBase;
        private readonly ICryptography _cryptography;

        public CategoriaRepository(IServiceProvider serviceProvider, ICryptography cryptography)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
            this._cryptography = cryptography;
        }

        public async Task<AgregarCategoriaCommandDTO> AgregarCategoria(AgregarCategoriaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnombre", command.Nombre.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pdescripcion", command.Descripcion.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pidTipoProducto", command.IdTipoProducto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_RegistrarCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                AgregarCategoriaCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<ObtenerCategoriaQueryDTO> ObtenerCategoria(ObtenerCategoriaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<Categoria> categorias = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTermino", query.Termino.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pPage", query.Pagina, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pCantidad", query.Cantidad, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@total", 0, DbType.Int32, ParameterDirection.Output);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString(),
                            TipoProducto = Convert.IsDBNull(reader["TIPO_PRODUCTO"]) ? "" : reader["TIPO_PRODUCTO"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString(),
                        });
                    }
                }
                ObtenerCategoriaQueryDTO response = new()
                {
                    Pagina = query.Pagina,
                    Total = parameters.Get<int>("@total"),
                    Categorias = categorias
                };
                return response;
            }
        }
        public async Task<EditarEstadoCategoriaCommandDTO> EditarEstadoCategoria(EditarEstadoCategoriaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidCategoria", command.IdCategoria, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_EditarEstadoCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                EditarEstadoCategoriaCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<VerCategoriaQueryDTO> VerCategoria(VerCategoriaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                VerCategoriaQueryDTO response = new();
                parameters.Add("@pIdCategoria", query.IdCategoria, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response = new VerCategoriaQueryDTO()
                        {
                            IdCategoria = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString(),
                            IdTipoProducto = Convert.IsDBNull(reader["TIPO_PRODUCTO"]) ? 0 : Convert.ToInt32(reader["TIPO_PRODUCTO"].ToString()),
                        };
                    }
                }
                return response;
            }
        }
        public async Task<EditarCategoriaCommandDTO> EditarCategoria(EditarCategoriaCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidCategoria", command.IdCategoria, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pdescripcion", command.Descripcion.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pidTipoProducto", command.IdTipoProducto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_EditarCategoria]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                EditarCategoriaCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<IEnumerable<ObtenerCategoriaMenuQueryDTO>> ObtenerCategoriaMenu(ObtenerCategoriaMenuQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerCategoriaMenuQueryDTO> response = new();
                DynamicParameters parameters = new DynamicParameters();

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerCategoriaMenu]",
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.Add(new ObtenerCategoriaMenuQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                        });
                    }
                }
                return response;
            }
        }
        public async Task<AgregarBeneficiosCommandDTO> AgregarBeneficio(AgregarBeneficiosCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidCategoria", command.IdCategoria, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pdescripcion", command.Descripcion.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pbeneficiosXml", this.ConvertToXMLBeneficio(command.Beneficios), DbType.Xml, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_RegistrarBeneficio]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                AgregarBeneficiosCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<ObtenerBeneficioQueryDTO> ObtenerBeneficio(ObtenerBeneficioQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerBeneficio> beneficios = new();
                ObtenerBeneficioQueryDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidCategoria", query.IdCategoria, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@descripcion", "", DbType.String, ParameterDirection.Output);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerBeneficio]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        beneficios.Add(new ObtenerBeneficio()
                        {
                            IdBeneficio = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                        });
                    }
                }
                response.Descripcion = parameters.Get<string>("@descripcion");
                response.Beneficios = beneficios;

                return response;
            }
        }

        private string ConvertToXMLBeneficio(List<Beneficio> beneficios)
        {
            if (beneficios == null || beneficios.Count == 0)
            {
                return "<Beneficios></Beneficios>";
            }

            var serializer = new XmlSerializer(typeof(List<Beneficio>), new XmlRootAttribute("Beneficios"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, beneficios, namespaces);
                return sw.ToString();
            }
        }
    }
}

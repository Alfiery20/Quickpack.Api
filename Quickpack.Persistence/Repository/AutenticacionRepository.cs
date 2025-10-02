using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Autenticacion.command.IniciarSesion;
using Quickpack.Application.Autenticacion.command.ObtenerMenu;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Persistence.Database;
using System.Data;

namespace Quickpack.Persistence.Repository
{
    public class AutenticacionRepository : IAutenticacionRepository
    {
        private readonly IDataBase _dataBase;
        private readonly ICryptography cryptography;

        public AutenticacionRepository(IServiceProvider serviceProvider, ICryptography cryptography)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
            this.cryptography = cryptography;
        }

        public async Task<IniciarSesionCommandDTO> IniciarSesion(IniciarSesionCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pemail", command.Correo.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pclave", this.cryptography.Encrypt(command.Clave.Trim()), DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_IniciarSesion]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    IniciarSesionCommandDTO response = new();
                    while (reader.Read())
                    {
                        response = new IniciarSesionCommandDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            TipoDocumento = Convert.IsDBNull(reader["TIPO_DOCUMENTO"]) ? "" : reader["TIPO_DOCUMENTO"].ToString(),
                            NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? "" : reader["APELLIDO_PATERNO"].ToString(),
                            ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? "" : reader["APELLIDO_MATERNO"].ToString(),
                            Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? "" : reader["TELEFONO"].ToString(),
                            IdRol = Convert.IsDBNull(reader["ID_ROL"]) ? 0 : Convert.ToInt32(reader["ID_ROL"].ToString()),
                            Rol = Convert.IsDBNull(reader["NOMBRE_ROL"]) ? "" : reader["NOMBRE_ROL"].ToString()
                        };
                    }
                    return response;
                }
            }
        }

        public async Task<IEnumerable<ObtenerMenuCommandDTO>> ObtenerMenu(ObtenerMenuCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdRol", command.IdRol, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pIdUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_ObtenerMenu]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<ObtenerMenuCommandDTO> response = new();
                    while (reader.Read())
                    {
                        response.Add(new ObtenerMenuCommandDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Ruta = Convert.IsDBNull(reader["RUTA"]) ? "" : reader["RUTA"].ToString(),
                            IdMenuPadre = Convert.IsDBNull(reader["ID_PADRE"]) ? 0 : Convert.ToInt32(reader["ID_PADRE"].ToString()),
                            Icono = Convert.IsDBNull(reader["ICONO"]) ? "" : reader["ICONO"].ToString(),
                            Orden = Convert.IsDBNull(reader["ORDEN"]) ? 0 : Convert.ToInt32(reader["ORDEN"].ToString())
                        });
                    }
                    return response;
                }
            }
        }
    }
}

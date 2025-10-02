using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Empleado.Command.AgregarEmpleado;
using Quickpack.Application.Empleado.Command.EditarEmpleado;
using Quickpack.Application.Empleado.Command.EditarEstadoEmpleado;
using Quickpack.Application.Empleado.Query.ObtenerEmpleado;
using Quickpack.Application.Empleado.Query.VerEmpleado;
using Quickpack.Application.Rol.Command.AgregarRol;
using Quickpack.Application.Rol.Query.ObtenerRol;
using Quickpack.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Persistence.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly IDataBase _dataBase;
        private readonly ICryptography _cryptography;

        public EmpleadoRepository(IServiceProvider serviceProvider, ICryptography cryptography)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
            this._cryptography = cryptography;
        }

        public async Task<ObtenerEmpleadoQueryDTO> ObtenerEmpleado(ObtenerEmpleadoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<Empleado> Empleados = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pNombre", query.Nombre.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pNroDocumento", query.NroDocumento.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pPage", query.Pagina, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pCantidad", query.Cantidad, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@total", 0, DbType.Int32, ParameterDirection.Output);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerEmpleado]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        Empleados.Add(new Empleado()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            TipoDocumento = Convert.IsDBNull(reader["TIPO_DOCUMENTO"]) ? "" : reader["TIPO_DOCUMENTO"].ToString(),
                            NroDocumento = Convert.IsDBNull(reader["NRO_DOCUMENTO"]) ? "" : reader["NRO_DOCUMENTO"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? "" : reader["APELLIDO_PATERNO"].ToString(),
                            ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? "" : reader["APELLIDO_MATERNO"].ToString(),
                            Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? "" : reader["TELEFONO"].ToString(),
                            Correo = Convert.IsDBNull(reader["CORREO"]) ? "" : reader["CORREO"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString(),
                            Rol = Convert.IsDBNull(reader["ROL"]) ? "" : reader["ROL"].ToString()
                        });
                    }
                }
                ObtenerEmpleadoQueryDTO response = new()
                {
                    Pagina = query.Pagina,
                    Total = parameters.Get<int>("@total"),
                    Empleados = Empleados
                };
                return response;
            }
        }
        public async Task<AgregarEmpleadoCommandDTO> AgregarEmpleado(AgregarEmpleadoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTipoDocumento", command.TipoDocumento.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pNroDocumento", command.NumeroDocumento.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pApellidoPaterno", command.ApellidoPaterno.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pApellidoMaterno", command.ApellidoMaterno.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pTelefono", command.Telefono.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pCorreo", command.Correo.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pClave", this._cryptography.Encrypt(command.Clave.Trim()), DbType.String, ParameterDirection.Input);
                parameters.Add("@pIdRol", command.IdRol, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[sp_RegistrarEmpleado]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                AgregarEmpleadoCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<EditarEstadoEmpleadoCommandDTO> EditarEstadoEmpleado(EditarEstadoEmpleadoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidEmpleado", command.IdEmpleado, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_CambiarEstadoEmpleado]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                EditarEstadoEmpleadoCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
        public async Task<VerEmpleadoQueryDTO> VerEmpleado(VerEmpleadoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                VerEmpleadoQueryDTO response = new();
                parameters.Add("@pIdEmpleado", query.IdEmpleado, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerEmpleado]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response = new VerEmpleadoQueryDTO()
                        {
                            IdEmpleado = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            TipoDocumento = Convert.IsDBNull(reader["TIPO_DOCUMENTO"]) ? "" : reader["TIPO_DOCUMENTO"].ToString(),
                            NumeroDocumento = Convert.IsDBNull(reader["NRO_DOCUMENTO"]) ? "" : reader["NRO_DOCUMENTO"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? "" : reader["APELLIDO_PATERNO"].ToString(),
                            ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? "" : reader["APELLIDO_MATERNO"].ToString(),
                            Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? "" : reader["TELEFONO"].ToString(),
                            Correo = Convert.IsDBNull(reader["CORREO"]) ? "" : reader["CORREO"].ToString(),
                            Rol = Convert.IsDBNull(reader["ROL"]) ? 0 : Convert.ToInt32(reader["ROL"].ToString())
                        };
                    }
                }
                return response;
            }
        }
        public async Task<EditarEmpleadoCommandDTO> EditarEmpleado(EditarEmpleadoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdEmpleado", command.IdEmpleado, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pnombre", command.Nombre.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pApellidoPaterno", command.ApellidoPaterno.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pApellidoMaterno", command.ApellidoMaterno.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pTelefono", command.Telefono.Trim(), DbType.String, ParameterDirection.Input);
                parameters.Add("@pIdRol", command.IdRol, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[usp_EditarEmpleado]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                EditarEmpleadoCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
    }
}

using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Quickpack.Application.Autenticacion.command.IniciarSesion;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Rol.Command;
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
    public class RolRepository : IRolRepository
    {
        private readonly IDataBase _dataBase;

        public RolRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<ObtenerRolQueryDTO> ObtenerRoles(ObtenerRolQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pTermino", query.Termino, DbType.String, ParameterDirection.Input);
                parameters.Add("@pPage", query.Pagina, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pCantidad", query.Cantidad, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@total", 0, DbType.Int32, ParameterDirection.Output);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerRol]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    List<Rol> roles = new();
                    while (reader.Read())
                    {
                        roles.Add(new Rol()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString(),
                        });
                    }
                    ObtenerRolQueryDTO response = new()
                    {
                        Roles = roles,
                        Pagina = query.Pagina,
                        Total = parameters.Get<int>("@total")
                    };
                    return response;
                }
            }
        }

        public async Task<AgregarRolCommandDTO> AgregarRol(AgregarRolCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pnombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@codigo", "", DbType.String, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                var reader = await cnx.ExecuteAsync(
                    "[dbo].[sp_RegistrarRol]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                AgregarRolCommandDTO response = new()
                {
                    Codigo = parameters.Get<string>("@codigo"),
                    Mensaje = parameters.Get<string>("@msj"),
                };
                return response;

            }
        }
    }
}

using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Autenticacion.command.ObtenerMenu;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Query.ObtenerPermisoRol
{
    public class ObtenerPermisoRolQueryHandler : IRequestHandler<ObtenerPermisoRolQuery, IEnumerable<ObtenerPermisoRolQueryDTO>>
    {
        private readonly ILogger<ObtenerPermisoRolQueryHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public ObtenerPermisoRolQueryHandler(
                ILogger<ObtenerPermisoRolQueryHandler> logger,
                IRolRepository rolRepository
            )
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public async Task<IEnumerable<ObtenerPermisoRolQueryDTO>> Handle(ObtenerPermisoRolQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler para Obtener permisos por Roles");
            var response = (await this._rolRepository.ObtenerPermisosRoles(request)).ToList();
            this.LlenarArreglo(response);
            this._logger.LogInformation("Finalizando handler para permisos por Roles");
            return response.Where(x => x.Padre == 0);
        }

        private void LlenarArreglo(List<ObtenerPermisoRolQueryDTO> command)
        {
            foreach (var menu in command)
            {
                var primerosHijos = command.Where(n => n.Padre == menu.IdMenu).ToList();
                menu.MenusHijos = primerosHijos;
                //this.LlenarArreglo(primerosHijos);
            }
        }
    }
}

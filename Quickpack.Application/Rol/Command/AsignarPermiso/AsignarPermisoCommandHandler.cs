using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Command.AsignarPermiso
{
    public class AsignarPermisoCommandHandler : IRequestHandler<AsignarPermisoCommand, AsignarPermisoCommandDTO>
    {
        private readonly ILogger<AsignarPermisoCommandHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public AsignarPermisoCommandHandler(
            ILogger<AsignarPermisoCommandHandler> logger,
            IRolRepository rolRepository
            )
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public Task<AsignarPermisoCommandDTO> Handle(AsignarPermisoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler para Asignar Permiso a Rol");
            var response = this._rolRepository.AsignarPermiso(request);
            this._logger.LogInformation("Finalizando handler para Asignar Permiso a Rol");
            return response;
        }
    }
}

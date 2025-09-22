using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Query.ObtenerRol
{
    public class ObtenerRolQueryHandler : IRequestHandler<ObtenerRolQuery, ObtenerRolQueryDTO>
    {
        private readonly ILogger<ObtenerRolQueryHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public ObtenerRolQueryHandler(
            ILogger<ObtenerRolQueryHandler> logger,
            IRolRepository rolRepository
            )
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public Task<ObtenerRolQueryDTO> Handle(ObtenerRolQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler para Obtener Roles");
            var response = this._rolRepository.ObtenerRoles(request);
            this._logger.LogInformation("Finalizando handler para Obtener Roles");
            return response;
        }
    }
}

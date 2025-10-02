using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Query.ObtenerRolMenu
{
    public class ObtenerRolMenuQueryHandler : IRequestHandler<ObtenerRolMenuQuery, IEnumerable<ObtenerRolMenuQueryDTO>>
    {
        private readonly ILogger<ObtenerRolMenuQueryHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public ObtenerRolMenuQueryHandler(
            ILogger<ObtenerRolMenuQueryHandler> logger,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public Task<IEnumerable<ObtenerRolMenuQueryDTO>> Handle(ObtenerRolMenuQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler obtener rol menu");
            var response = this._rolRepository.ObtenerRoleMenu();
            this._logger.LogInformation("Finalizando handler obtener rol menu");
            return response;
        }
    }
}

using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Landing.Query.ObtenerTipoProductoLanding
{
    public class ObtenerTipoProductoLandingQueryHandler : IRequestHandler<ObtenerTipoProductoLandingQuery, ObtenerTipoProductoLandingQueryDTO>
    {
        private readonly ILogger<ObtenerTipoProductoLandingQueryHandler> _logger;
        private readonly ILandingRepository _landingRepository;

        public ObtenerTipoProductoLandingQueryHandler(
            ILogger<ObtenerTipoProductoLandingQueryHandler> logger,
            ILandingRepository landingRepository)
        {
            this._logger = logger;
            this._landingRepository = landingRepository;
        }
        public async Task<ObtenerTipoProductoLandingQueryDTO> Handle(ObtenerTipoProductoLandingQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            var response = await this._landingRepository.ObtenerTipoProductoLanding(request);
            response.Categorias = await this._landingRepository.ObtenerTipoProductoCategoriaLanding(request);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return response;
        }
    }
}

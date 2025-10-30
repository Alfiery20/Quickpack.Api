using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Landing.Query.ObtenerCategoriaMenuLanding
{
    public class ObtenerTipoProductoMenuLandingQueryHandler : IRequestHandler<ObtenerTipoProductoMenuLandingQuery, IEnumerable<ObtenerTipoProductoMenuLandingQueryDTO>>
    {
        private readonly ILogger<ObtenerTipoProductoMenuLandingQueryHandler> _logger;
        private readonly ILandingRepository _landingRepository;

        public ObtenerTipoProductoMenuLandingQueryHandler(
            ILogger<ObtenerTipoProductoMenuLandingQueryHandler> logger,
            ILandingRepository landingRepository)
        {
            this._logger = logger;
            this._landingRepository = landingRepository;
        }
        public Task<IEnumerable<ObtenerTipoProductoMenuLandingQueryDTO>> Handle(ObtenerTipoProductoMenuLandingQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            var response = this._landingRepository.ObtenerTipoProductoMenuLanding(request);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return response;
        }
    }
}



using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;

namespace Quickpack.Application.Landing.Query.ObtenerCategoriaLanding
{
    public class ObtenerCategoriaLandingQueryHandler : IRequestHandler<ObtenerCategoriaLandingQuery, ObtenerCategoriaLandingQueryDTO>
    {
        private readonly ILogger<ObtenerCategoriaLandingQueryHandler> _logger;
        private readonly ILandingRepository _landingRepository;

        public ObtenerCategoriaLandingQueryHandler(
            ILogger<ObtenerCategoriaLandingQueryHandler> logger,
            ILandingRepository landingRepository)
        {
            this._logger = logger;
            this._landingRepository = landingRepository;
        }

        public async Task<ObtenerCategoriaLandingQueryDTO> Handle(ObtenerCategoriaLandingQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            var response = await this._landingRepository.ObtenerCategoriaLanding(request);
            response.Producto = await this._landingRepository.ObtenerCategoriaProductoLanding(request);
            response.Beneficios = await this._landingRepository.ObtenerBeneficioCategoriaLanding(request);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return response;
        }
    }
}

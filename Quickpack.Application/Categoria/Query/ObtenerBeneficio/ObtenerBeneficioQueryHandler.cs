using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.ObtenerBeneficio
{
    public class ObtenerBeneficioQueryHandler : IRequestHandler<ObtenerBeneficioQuery, ObtenerBeneficioQueryDTO>
    {
        private readonly ILogger<ObtenerBeneficioQueryHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public ObtenerBeneficioQueryHandler(
            ILogger<ObtenerBeneficioQueryHandler> logger,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<ObtenerBeneficioQueryDTO> Handle(ObtenerBeneficioQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.ObtenerBeneficio(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

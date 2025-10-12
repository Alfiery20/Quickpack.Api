using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.AgregarBeneficios
{
    public class AgregarBeneficiosCommandHandler : IRequestHandler<AgregarBeneficiosCommand, AgregarBeneficiosCommandDTO>
    {
        private readonly ILogger<AgregarBeneficiosCommandHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public AgregarBeneficiosCommandHandler(
            ILogger<AgregarBeneficiosCommandHandler> logger,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<AgregarBeneficiosCommandDTO> Handle(AgregarBeneficiosCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.AgregarBeneficio(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

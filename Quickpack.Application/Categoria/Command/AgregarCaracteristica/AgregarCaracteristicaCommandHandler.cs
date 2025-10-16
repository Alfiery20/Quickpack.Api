using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.AgregarCaracteristica
{
    public class AgregarCaracteristicaCommandHandler : IRequestHandler<AgregarCaracteristicaCommand, AgregarCaracteristicaCommandDTO>
    {
        private readonly ILogger<AgregarCaracteristicaCommandHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public AgregarCaracteristicaCommandHandler(
            ILogger<AgregarCaracteristicaCommandHandler> logger,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<AgregarCaracteristicaCommandDTO> Handle(AgregarCaracteristicaCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.AgregarCaracteristica(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

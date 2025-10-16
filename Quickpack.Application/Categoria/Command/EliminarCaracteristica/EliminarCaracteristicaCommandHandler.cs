using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.EliminarCaracteristica
{
    public class EliminarCaracteristicaCommandHandler : IRequestHandler<EliminarCaracteristicaCommand, EliminarCaracteristicaCommandDTO>
    {
        private readonly ILogger<EliminarCaracteristicaCommandHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public EliminarCaracteristicaCommandHandler(
            ILogger<EliminarCaracteristicaCommandHandler> logger,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<EliminarCaracteristicaCommandDTO> Handle(EliminarCaracteristicaCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.EliminarCaracteristica(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

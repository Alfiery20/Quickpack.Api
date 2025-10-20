using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.VerCaracteristica
{
    public class VerCaracteristicaQueryHandler : IRequestHandler<VerCaracteristicaQuery, VerCaracteristicaQueryDTO>
    {
        private readonly ILogger<VerCaracteristicaQueryHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public VerCaracteristicaQueryHandler(
            ILogger<VerCaracteristicaQueryHandler> logger,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<VerCaracteristicaQueryDTO> Handle(VerCaracteristicaQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.VerCaracteristica(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

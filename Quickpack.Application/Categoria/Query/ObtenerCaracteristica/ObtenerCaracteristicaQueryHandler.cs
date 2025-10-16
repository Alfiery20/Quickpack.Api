using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.ObtenerCaracteristica
{
    public class ObtenerCaracteristicaQueryHandler : IRequestHandler<ObtenerCaracteristicaQuery, IEnumerable<ObtenerCaracteristicaQueryDTO>>
    {
        private readonly ILogger<ObtenerCaracteristicaQueryHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public ObtenerCaracteristicaQueryHandler(
            ILogger<ObtenerCaracteristicaQueryHandler> _logger,
            ICategoriaRepository _categoriaRepository)
        {
            this._logger = _logger;
            this._categoriaRepository = _categoriaRepository;
        }
        public Task<IEnumerable<ObtenerCaracteristicaQueryDTO>> Handle(ObtenerCaracteristicaQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.ObtenerCaracteristica(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

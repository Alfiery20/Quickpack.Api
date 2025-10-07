using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Query.VerTipoProducto
{
    public class VerTipoProductoQueryHandler : IRequestHandler<VerTipoProductoQuery, VerTipoProductoQueryDTO>
    {
        private readonly ILogger<VerTipoProductoQueryHandler> _logger;
        private readonly ITipoProductoRepository _tipoProductoRepository;

        public VerTipoProductoQueryHandler(
            ILogger<VerTipoProductoQueryHandler> logger,
            ITipoProductoRepository tipoProductoRepository)
        {
            this._logger = logger;
            this._tipoProductoRepository = tipoProductoRepository;
        }
        public Task<VerTipoProductoQueryDTO> Handle(VerTipoProductoQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler ver Tipo Producto");
            var response = this._tipoProductoRepository.VerTipoProducto(request);
            this._logger.LogInformation("Finalizando handler ver Tipo Producto");
            return response;
        }
    }
}

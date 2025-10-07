using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Query.ObtenerTipoProducto
{
    public class ObtenerTipoProductoQueryHandler : IRequestHandler<ObtenerTipoProductoQuery, ObtenerTipoProductoQueryDTO>
    {
        private readonly ILogger<ObtenerTipoProductoQueryHandler> _logger;
        private readonly ITipoProductoRepository _tipoProductoRepository;

        public ObtenerTipoProductoQueryHandler(
            ILogger<ObtenerTipoProductoQueryHandler> logger,
            ITipoProductoRepository tipoProductoRepository)
        {
            this._logger = logger;
            this._tipoProductoRepository = tipoProductoRepository;
        }
        public Task<ObtenerTipoProductoQueryDTO> Handle(ObtenerTipoProductoQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler editar Tipo Producto");
            var response = this._tipoProductoRepository.ObtenerTipoProducto(request);
            this._logger.LogInformation("Finalizando handler editar Tipo Producto");
            return response;
        }
    }
}

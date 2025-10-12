using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Query.ObtenerTipoProductoMenu
{
    public class ObtenerTipoProductoMenuQueryHandler : IRequestHandler<ObtenerTipoProductoMenuQuery, IEnumerable<ObtenerTipoProductoMenuQueryDTO>>
    {
        private readonly ILogger<ObtenerTipoProductoMenuQueryHandler> _logger;
        private readonly ITipoProductoRepository _tipoProductoRepository;

        public ObtenerTipoProductoMenuQueryHandler(
            ILogger<ObtenerTipoProductoMenuQueryHandler> logger,
            ITipoProductoRepository tipoProductoRepository)
        {
            this._logger = logger;
            this._tipoProductoRepository = tipoProductoRepository;
        }
        public Task<IEnumerable<ObtenerTipoProductoMenuQueryDTO>> Handle(ObtenerTipoProductoMenuQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler de Obtener Tipo Producto Menu");
            var response = this._tipoProductoRepository.ObtenerTipoProductoMenu(request);
            this._logger.LogInformation("Finalizando handler de Obtener Tipo Producto Menu");
            return response;
        }
    }
}

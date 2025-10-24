using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Producto.Command.AgregarProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Query.VerProducto
{
    public class VerProductoQueryHandler : IRequestHandler<VerProductoQuery, VerProductoQueryDTO>
    {
        private readonly ILogger<AgregarProductoCommandHandler> _logger;
        private readonly IProductoRepository _productoRepository;

        public VerProductoQueryHandler(
            ILogger<AgregarProductoCommandHandler> logger,
            IProductoRepository productoRepository)
        {
            this._logger = logger;
            this._productoRepository = productoRepository;
        }

        public Task<VerProductoQueryDTO> Handle(VerProductoQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            var response = this._productoRepository.VerProducto(request);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return response;
        }
    }
}

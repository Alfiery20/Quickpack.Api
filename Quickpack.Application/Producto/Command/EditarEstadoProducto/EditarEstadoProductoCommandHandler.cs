using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Producto.Command.AgregarProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Command.EditarEstadoProducto
{
    public class EditarEstadoProductoCommandHandler : IRequestHandler<EditarEstadoProductoCommand, EditarEstadoProductoCommandDTO>
    {
        private readonly ILogger<EditarEstadoProductoCommandHandler> _logger;
        private readonly IProductoRepository _productoRepository;

        public EditarEstadoProductoCommandHandler(
            ILogger<EditarEstadoProductoCommandHandler> logger,
            IProductoRepository productoRepository)
        {
            this._logger = logger;
            this._productoRepository = productoRepository;
        }

        public Task<EditarEstadoProductoCommandDTO> Handle(EditarEstadoProductoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            var response = this._productoRepository.EditarEstadoProducto(request);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return response;
        }
    }
}

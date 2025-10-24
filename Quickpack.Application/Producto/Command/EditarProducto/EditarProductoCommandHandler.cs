using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using Quickpack.Application.Producto.Command.AgregarProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Command.EditarProducto
{
    public class EditarProductoCommandHandler : IRequestHandler<EditarProductoCommand, EditarProductoCommandDTO>
    {
        private readonly ILogger<AgregarProductoCommandHandler> _logger;
        private readonly IProductoRepository _productoRepository;
        private readonly IDateTimeService _dateTimeService;

        public EditarProductoCommandHandler(
            ILogger<AgregarProductoCommandHandler> logger,
            IProductoRepository productoRepository,
            IDateTimeService dateTimeService)
        {
            this._logger = logger;
            this._productoRepository = productoRepository;
            this._dateTimeService = dateTimeService;
        }

        public Task<EditarProductoCommandDTO> Handle(EditarProductoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            request.Fecha = this._dateTimeService.HoraLocal();
            var response = this._productoRepository.EditarProducto(request);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return response;
        }
    }
}

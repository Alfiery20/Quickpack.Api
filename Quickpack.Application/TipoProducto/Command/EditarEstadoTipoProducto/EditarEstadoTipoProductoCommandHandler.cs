using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Command.EditarEstadoTipoProducto
{
    public class EditarEstadoTipoProductoCommandHandler : IRequestHandler<EditarEstadoTipoProductoCommand, EditarEstadoTipoProductoCommandDTO>
    {
        private readonly ILogger<EditarEstadoTipoProductoCommandHandler> _logger;
        private readonly ITipoProductoRepository _tipoProductoRepository;

        public EditarEstadoTipoProductoCommandHandler(
            ILogger<EditarEstadoTipoProductoCommandHandler> logger,
            ITipoProductoRepository tipoProductoRepository)
        {
            this._logger = logger;
            this._tipoProductoRepository = tipoProductoRepository;
        }
        public Task<EditarEstadoTipoProductoCommandDTO> Handle(EditarEstadoTipoProductoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler editar estado Tipo de Producto");
            var response = this._tipoProductoRepository.EditarEstadoTipoProducto(request);
            this._logger.LogInformation("Finalizando handler editar estado Tipo de Producto");
            return response;
        }
    }
}

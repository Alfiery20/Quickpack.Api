using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Command.EditarTipoProducto
{
    public class EditarTipoProductoCommandHandler : IRequestHandler<EditarTipoProductoCommand, EditarTipoProductoCommandDTO>
    {
        private readonly ILogger<EditarTipoProductoCommandHandler> _logger;
        private readonly ITipoProductoRepository _tipoProductoRepository;

        public EditarTipoProductoCommandHandler(
            ILogger<EditarTipoProductoCommandHandler> logger,
            ITipoProductoRepository tipoProductoRepository)
        {
            this._logger = logger;
            this._tipoProductoRepository = tipoProductoRepository;
        }
        public Task<EditarTipoProductoCommandDTO> Handle(EditarTipoProductoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler editar Tipo Producto");
            var response = this._tipoProductoRepository.EditarTipoProducto(request);
            this._logger.LogInformation("Finalizando handler editar Tipo Producto");
            return response;
        }
    }
}

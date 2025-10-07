using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.TipoProducto.Command.AgregarTipoProducto
{
    public class AgregarTipoProductoCommandHandler : IRequestHandler<AgregarTipoProductoCommand, AgregarTipoProductoCommandDTO>
    {
        private readonly ILogger<AgregarTipoProductoCommandHandler> _logger;
        private readonly ITipoProductoRepository _tipoProductoRepository;

        public AgregarTipoProductoCommandHandler(
            ILogger<AgregarTipoProductoCommandHandler> logger,
            ITipoProductoRepository tipoProductoRepository)
        {
            this._logger = logger;
            this._tipoProductoRepository = tipoProductoRepository;
        }
        public Task<AgregarTipoProductoCommandDTO> Handle(AgregarTipoProductoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler Agregar Tipo de Producto");
            var response = this._tipoProductoRepository.AgregarTipoProducto(request);
            this._logger.LogInformation("Finalizando handler Agregar Tipo de Producto");
            return response;
        }
    }
}

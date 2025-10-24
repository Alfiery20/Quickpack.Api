using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Command.AgregarFichaTecnica
{
    public class AgregarFichaTecnicaCommandHandler : IRequestHandler<AgregarFichaTecnicaCommand, AgregarFichaTecnicaCommandDTO>
    {
        private readonly ILogger<AgregarFichaTecnicaCommandHandler> _logger;
        private readonly IProductoRepository _productoRepository;

        public AgregarFichaTecnicaCommandHandler(
            ILogger<AgregarFichaTecnicaCommandHandler> logger,
            IProductoRepository productoRepository)
        {
            this._logger = logger;
            this._productoRepository = productoRepository;
        }
        public Task<AgregarFichaTecnicaCommandDTO> Handle(AgregarFichaTecnicaCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            var response = this._productoRepository.AgregarFichaTecnica(request);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return response;
        }
    }
}

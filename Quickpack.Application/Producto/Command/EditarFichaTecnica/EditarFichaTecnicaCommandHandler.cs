using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Command.EditarFichaTecnica
{
    public class EditarFichaTecnicaCommandHandler : IRequestHandler<EditarFichaTecnicaCommand, EditarFichaTecnicaCommandDTO>
    {
        private readonly ILogger<EditarFichaTecnicaCommandHandler> _logger;
        private readonly IProductoRepository _productoRepository;

        public EditarFichaTecnicaCommandHandler(
            ILogger<EditarFichaTecnicaCommandHandler> logger,
            IProductoRepository productoRepository)
        {
            this._logger = logger;
            this._productoRepository = productoRepository;
        }
        public Task<EditarFichaTecnicaCommandDTO> Handle(EditarFichaTecnicaCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            var response = this._productoRepository.EditarFichaTecnica(request);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return response;
        }
    }
}

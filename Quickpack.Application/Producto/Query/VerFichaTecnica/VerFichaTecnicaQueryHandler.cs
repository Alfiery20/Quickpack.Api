using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Query.VerFichaTecnica
{
    public class VerFichaTecnicaQueryHandler : IRequestHandler<VerFichaTecnicaQuery, VerFichaTecnicaQueryDTO>
    {
        private readonly ILogger<VerFichaTecnicaQueryHandler> _logger;
        private readonly IProductoRepository _productoRepository;

        public VerFichaTecnicaQueryHandler(
            ILogger<VerFichaTecnicaQueryHandler> logger,
            IProductoRepository productoRepository)
        {
            this._logger = logger;
            this._productoRepository = productoRepository;
        }
        public Task<VerFichaTecnicaQueryDTO> Handle(VerFichaTecnicaQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            var response = this._productoRepository.VerFichaTecnica(request);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return response;
        }
    }
}

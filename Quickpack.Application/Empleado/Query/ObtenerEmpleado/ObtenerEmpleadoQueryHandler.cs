using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Empleado.Query.ObtenerEmpleado
{
    public class ObtenerEmpleadoQueryHandler : IRequestHandler<ObtenerEmpleadoQuery, ObtenerEmpleadoQueryDTO>
    {
        private readonly ILogger<ObtenerEmpleadoQueryHandler> _logger;
        private readonly IEmpleadoRepository _empleadoRepository;

        public ObtenerEmpleadoQueryHandler(
                ILogger<ObtenerEmpleadoQueryHandler> logger,
                IEmpleadoRepository empleadoRepository
            )
        {
            this._logger = logger;
            this._empleadoRepository = empleadoRepository;
        }
        public Task<ObtenerEmpleadoQueryDTO> Handle(ObtenerEmpleadoQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler obtener empleado");
            var response = this._empleadoRepository.ObtenerEmpleado(request);
            this._logger.LogInformation("Finalizando handler obtener empleado");
            return response;
        }
    }
}

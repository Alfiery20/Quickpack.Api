using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Empleado.Query.VerEmpleado
{
    public class VerEmpleadoQueryHandler : IRequestHandler<VerEmpleadoQuery, VerEmpleadoQueryDTO>
    {
        private readonly ILogger<VerEmpleadoQueryHandler> _logger;
        private readonly IEmpleadoRepository _empleadoRepository;

        public VerEmpleadoQueryHandler(
            ILogger<VerEmpleadoQueryHandler> logger,
            IEmpleadoRepository empleadoRepository)
        {
            this._logger = logger;
            this._empleadoRepository = empleadoRepository;
        }
        public Task<VerEmpleadoQueryDTO> Handle(VerEmpleadoQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler de ver empleado");
            var response = this._empleadoRepository.VerEmpleado(request);
            this._logger.LogInformation("Finalizando handler de ver empleado");
            return response;
        }
    }
}

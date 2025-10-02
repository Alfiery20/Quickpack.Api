using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Empleado.Command.AgregarEmpleado
{
    public class AgregarEmpleadoCommandHandler : IRequestHandler<AgregarEmpleadoCommand, AgregarEmpleadoCommandDTO>
    {
        private readonly ILogger<AgregarEmpleadoCommandHandler> _logger;
        private readonly IEmpleadoRepository _empleadoRepository;

        public AgregarEmpleadoCommandHandler(
            ILogger<AgregarEmpleadoCommandHandler> logger,
            IEmpleadoRepository empleadoRepository)
        {
            this._logger = logger;
            this._empleadoRepository = empleadoRepository;
        }
        public Task<AgregarEmpleadoCommandDTO> Handle(AgregarEmpleadoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            var response = this._empleadoRepository.AgregarEmpleado(request);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return response;
        }
    }
}

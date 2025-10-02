using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Empleado.Command.EditarEmpleado
{
    public class EditarEmpleadoCommandHandler : IRequestHandler<EditarEmpleadoCommand, EditarEmpleadoCommandDTO>
    {
        private readonly ILogger<EditarEmpleadoCommandHandler> _logger;
        private readonly IEmpleadoRepository _empleadoRepository;

        public EditarEmpleadoCommandHandler(
            ILogger<EditarEmpleadoCommandHandler> logger,
            IEmpleadoRepository empleadoRepository)
        {
            this._logger = logger;
            this._empleadoRepository = empleadoRepository;
        }
        public Task<EditarEmpleadoCommandDTO> Handle(EditarEmpleadoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler de editar empleado");
            var response = this._empleadoRepository.EditarEmpleado(request);
            this._logger.LogInformation("Finalizando handler de editar empleado");
            return response;
        }
    }
}

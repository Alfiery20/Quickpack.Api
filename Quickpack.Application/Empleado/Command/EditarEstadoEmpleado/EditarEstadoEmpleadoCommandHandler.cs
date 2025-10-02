using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Empleado.Command.EditarEstadoEmpleado
{
    public class EditarEstadoEmpleadoCommandHandler : IRequestHandler<EditarEstadoEmpleadoCommand, EditarEstadoEmpleadoCommandDTO>
    {
        private readonly ILogger<EditarEstadoEmpleadoCommandHandler> _logger;
        private readonly IEmpleadoRepository _empleadoRepository;

        public EditarEstadoEmpleadoCommandHandler(
            ILogger<EditarEstadoEmpleadoCommandHandler> logger,
            IEmpleadoRepository empleadoRepository)
        {
            this._logger = logger;
            this._empleadoRepository = empleadoRepository;
        }
        public Task<EditarEstadoEmpleadoCommandDTO> Handle(EditarEstadoEmpleadoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler editar estado empleado");
            var response = this._empleadoRepository.EditarEstadoEmpleado(request);
            this._logger.LogInformation("Finalizando handler editar estado empleado");
            return response;
        }
    }
}

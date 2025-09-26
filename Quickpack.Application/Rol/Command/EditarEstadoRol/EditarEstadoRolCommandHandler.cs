using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Command.EditarEstadoRol
{
    public class EditarEstadoRolCommandHandler : IRequestHandler<EditarEstadoRolCommand, EditarEstadoRolCommandDTO>
    {
        private readonly ILogger<EditarEstadoRolCommandHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public EditarEstadoRolCommandHandler(
                ILogger<EditarEstadoRolCommandHandler> logger,
                IRolRepository rolRepository
            )
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public Task<EditarEstadoRolCommandDTO> Handle(EditarEstadoRolCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler editar estado rol");
            var response = this._rolRepository.EditarEstadoRol(request);
            this._logger.LogInformation("Finalizando handler editar estado rol");
            return response;
        }
    }
}

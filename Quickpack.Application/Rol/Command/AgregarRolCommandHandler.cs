using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Command
{
    public class AgregarRolCommandHandler : IRequestHandler<AgregarRolCommand, AgregarRolCommandDTO>
    {
        private readonly ILogger<AgregarRolCommandHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public AgregarRolCommandHandler(
                ILogger<AgregarRolCommandHandler> logger,
                IRolRepository rolRepository
            )
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public Task<AgregarRolCommandDTO> Handle(AgregarRolCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler para Agregar Rol");
            var response = this._rolRepository.AgregarRol(request);
            this._logger.LogInformation("Terminando handler para Agregar Rol");
            return response;
        }
    }
}

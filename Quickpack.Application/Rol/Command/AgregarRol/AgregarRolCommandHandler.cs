using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Command.AgregarRol
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
            _logger = logger;
            _rolRepository = rolRepository;
        }
        public Task<AgregarRolCommandDTO> Handle(AgregarRolCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando handler para Agregar Rol");
            var response = _rolRepository.AgregarRol(request);
            _logger.LogInformation("Terminando handler para Agregar Rol");
            return response;
        }
    }
}

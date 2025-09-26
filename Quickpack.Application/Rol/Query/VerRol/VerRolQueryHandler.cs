using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Rol.Query.VerRol
{
    public class VerRolQueryHandler : IRequestHandler<VerRolQuery, VerRolQueryDTO>
    {
        private readonly ILogger<VerRolQueryDTO> _logger;
        private readonly IRolRepository _rolRepository;

        public VerRolQueryHandler(
            ILogger<VerRolQueryDTO> logger,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public Task<VerRolQueryDTO> Handle(VerRolQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando consulta de rol por Id");
            var response = this._rolRepository.VerRole(request);
            this._logger.LogInformation("Finalizando consulta de rol por Id");
            return response;
        }
    }
}

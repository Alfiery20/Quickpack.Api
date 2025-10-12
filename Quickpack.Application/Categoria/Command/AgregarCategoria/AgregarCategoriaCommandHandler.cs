using MediatR;
using MediatR.Wrappers;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.AgregarCategoria
{
    public class AgregarCategoriaCommandHandler : IRequestHandler<AgregarCategoriaCommand, AgregarCategoriaCommandDTO>
    {
        private readonly ILogger<AgregarCategoriaCommandHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public AgregarCategoriaCommandHandler(
            ILogger<AgregarCategoriaCommandHandler> logger,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<AgregarCategoriaCommandDTO> Handle(AgregarCategoriaCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.AgregarCategoria(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

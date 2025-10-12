using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.CambiarEstadoCategoria
{
    public class EditarEstadoCategoriaCommandHandler : IRequestHandler<EditarEstadoCategoriaCommand, EditarEstadoCategoriaCommandDTO>
    {
        private readonly ILogger<EditarEstadoCategoriaCommandHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public EditarEstadoCategoriaCommandHandler(
            ILogger<EditarEstadoCategoriaCommandHandler> logger,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<EditarEstadoCategoriaCommandDTO> Handle(EditarEstadoCategoriaCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.EditarEstadoCategoria(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

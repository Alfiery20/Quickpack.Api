using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Categoria.Command.CambiarEstadoCategoria;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.EditarCategoria
{
    public class EditarCategoriaCommandHandler : IRequestHandler<EditarCategoriaCommand, EditarCategoriaCommandDTO>
    {
        private readonly ILogger<EditarCategoriaCommandHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public EditarCategoriaCommandHandler(
            ILogger<EditarCategoriaCommandHandler> logger,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<EditarCategoriaCommandDTO> Handle(EditarCategoriaCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.EditarCategoria(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

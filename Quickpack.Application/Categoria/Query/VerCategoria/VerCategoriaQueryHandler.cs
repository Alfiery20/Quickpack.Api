using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.VerCategoria
{
    public class VerCategoriaQueryHandler : IRequestHandler<VerCategoriaQuery, VerCategoriaQueryDTO>
    {
        private readonly ILogger<VerCategoriaQueryHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public VerCategoriaQueryHandler(
            ILogger<VerCategoriaQueryHandler> logger,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<VerCategoriaQueryDTO> Handle(VerCategoriaQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.VerCategoria(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

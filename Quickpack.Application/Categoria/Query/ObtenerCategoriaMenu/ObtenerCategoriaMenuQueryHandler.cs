using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.ObtenerCategoriaMenu
{
    public class ObtenerCategoriaMenuQueryHandler : IRequestHandler<ObtenerCategoriaMenuQuery, IEnumerable<ObtenerCategoriaMenuQueryDTO>>
    {
        private readonly ILogger<ObtenerCategoriaMenuQueryHandler> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public ObtenerCategoriaMenuQueryHandler(
            ILogger<ObtenerCategoriaMenuQueryHandler> logger,
            ICategoriaRepository categoriaRepository)
        {
            this._logger = logger;
            this._categoriaRepository = categoriaRepository;
        }
        public Task<IEnumerable<ObtenerCategoriaMenuQueryDTO>> Handle(ObtenerCategoriaMenuQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler {Handler}", GetType().Name);
            var response = this._categoriaRepository.ObtenerCategoriaMenu(request);
            this._logger.LogInformation("Finalizando handler {Handler}", GetType().Name);
            return response;
        }
    }
}

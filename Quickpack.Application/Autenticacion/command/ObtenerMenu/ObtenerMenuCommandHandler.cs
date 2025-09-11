using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface.Repositories;

namespace Quickpack.Application.Autenticacion.command.ObtenerMenu
{
    public class ObtenerMenuCommandHandler : IRequestHandler<ObtenerMenuCommand, IEnumerable<ObtenerMenuCommandDTO>>
    {
        private readonly ILogger<ObtenerMenuCommandHandler> _logger;
        private readonly IAutenticacionRepository _autenticacionRepository;

        public ObtenerMenuCommandHandler(
            ILogger<ObtenerMenuCommandHandler> logger,
            IAutenticacionRepository autenticacionRepository)
        {
            this._logger = logger;
            this._autenticacionRepository = autenticacionRepository;
        }
        public async Task<IEnumerable<ObtenerMenuCommandDTO>> Handle(ObtenerMenuCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler para Obtener Menu");
            var response = await this._autenticacionRepository.ObtenerMenu(request);
            this.LlenarArreglo(response.ToList());
            this._logger.LogInformation("Fin de handler para Obtener Menu");
            return response.Where(x => x.IdMenuPadre == 0);
        }

        private void LlenarArreglo(List<ObtenerMenuCommandDTO> command)
        {
            foreach (var menu in command)
            {
                var primerosHijos = command.Where(n => n.IdMenuPadre == menu.Id).OrderBy(n => n.Orden).ToList();
                menu.MenuHijo = primerosHijos;
                this.LlenarArreglo(primerosHijos);
            }
        }
    }
}

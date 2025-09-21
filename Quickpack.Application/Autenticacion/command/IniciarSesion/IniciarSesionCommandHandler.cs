using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Autenticacion.command.ObtenerMenu;
using Quickpack.Application.Common.Interface;
using Quickpack.Application.Common.Interface.Repositories;
using System.Security.Claims;
using System.Text.Json;

namespace Quickpack.Application.Autenticacion.command.IniciarSesion
{
    public class IniciarSesionCommandHandler : IRequestHandler<IniciarSesionCommand, IniciarSesionCommandDTO>
    {
        private readonly ILogger<IniciarSesionCommandHandler> _logger;
        private readonly IAutenticacionRepository _autenticacionRepository;
        private readonly IJwtService _jwtService;
        private readonly IDateTimeService _dateTimeService;

        public IniciarSesionCommandHandler(
            ILogger<IniciarSesionCommandHandler> logger,
            IAutenticacionRepository autenticacionRepository,
            IJwtService jwtService,
            IDateTimeService dateTimeService)
        {
            this._logger = logger;
            this._autenticacionRepository = autenticacionRepository;
            this._jwtService = jwtService;
            this._dateTimeService = dateTimeService;
        }

        public async Task<IniciarSesionCommandDTO> Handle(IniciarSesionCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler para Iniciar Sesion");
            var response = await this._autenticacionRepository.IniciarSesion(request);
            if (response.Id != 0)
            {
                response.Token = this.GenerateToken(response);
            }
            this._logger.LogInformation("Fin de handler para Iniciar Sesion");
            return response;
        }

        private string GenerateToken(IniciarSesionCommandDTO command)
        {
            var menus = this._autenticacionRepository.ObtenerMenu(new ObtenerMenuCommand()
            {
                IdRol = command.IdRol,
                IdUsuario = command.Id
            }).Result.ToList();
            var claims = new List<Claim>
            {
                new Claim("id", command.Id.ToString() ?? ""),
                new Claim("tipo_documento", command.TipoDocumento ?? ""),
                new Claim("numero_documento", command.NumeroDocumento ?? ""),
                new Claim("nombre", command.Nombre ?? ""),
                new Claim("apellido_paterno", command.ApellidoPaterno ?? ""),
                new Claim("apellido_materno", command.ApellidoMaterno ?? ""),
                new Claim("telefono", command.Telefono ?? ""),
                new Claim("id_rol", command.IdRol.ToString() ?? ""),
                new Claim("rol", command.Rol.ToString() ?? ""),
                new Claim("permisos", JsonSerializer.Serialize(menus))
            };

            var token = _jwtService.Generate(claims.ToArray(), this._dateTimeService.HoraLocal());

            return token;
        }
    }
}

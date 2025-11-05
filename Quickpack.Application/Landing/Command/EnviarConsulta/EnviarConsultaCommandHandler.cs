using MediatR;
using Microsoft.Extensions.Logging;
using Quickpack.Application.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Landing.Command.EnviarConsulta
{
    public class EnviarConsultaCommandHandler : IRequestHandler<EnviarConsultaCommand, EnviarConsultaCommandDTO>
    {
        private readonly ILogger<EnviarConsultaCommandHandler> _logger;
        private readonly IEmealService _emealService;
        private readonly IDateTimeService _dateTimeService;

        public EnviarConsultaCommandHandler(
            ILogger<EnviarConsultaCommandHandler> logger,
            IEmealService emealService,
            IDateTimeService dateTimeService)
        {
            this._logger = logger;
            this._emealService = emealService;
            this._dateTimeService = dateTimeService;
        }
        public Task<EnviarConsultaCommandDTO> Handle(EnviarConsultaCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler agregar empleado");
            var asunto = $"[{request.TipoSolicitud}] Nueva Solicitud Mensajes - {request.NombreCompleto}";
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Utils", "Templates", "EmailTemplateNotification.html");
            string logo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Utils", "Templates", "Logo.png");
            string html = File.ReadAllText(ruta)
                            .Replace("{{TIPO_SOLICITUD}}", request.TipoSolicitud)
                            .Replace("{{NOMBRE_COMPLETO}}", request.NombreCompleto)
                            .Replace("{{EMAIL}}", request.Correo)
                            .Replace("{{TELEFONO}}", request.Telefono)
                            .Replace("{{EMPRESA}}", request.Empresa)
                            .Replace("{{POBLACION}}", Convert.ToString(request.Poblacion))
                            .Replace("{{MENSAJE}}", request.Mensaje)
                            .Replace("{{YEAR}}", Convert.ToString(this._dateTimeService.HoraLocal().Year))
                            ;
            var respuesta = this._emealService.EnviarCorreo(request.Correo, asunto, html);
            this._logger.LogInformation("Finalizando handler agregar empleado");
            return Task.FromResult(new EnviarConsultaCommandDTO
            {
                Codigo = respuesta,
                Mensaje = respuesta == "OK" ? "Correo enviado correctamente" : "Error al enviar correo, por favor contactar con servicio."
            });
        }
    }
}

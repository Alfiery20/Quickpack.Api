using Microsoft.Extensions.Configuration;
using Quickpack.Application.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Infrastructure.Services
{
    public class EmealService : IEmealService
    {
        private readonly string _smtpServer;
        private readonly int _port;
        private readonly string _senderEmail;
        private readonly string _password;
        private readonly string _support;
        private readonly IConfiguration _configuration;

        public EmealService(IConfiguration configuration)
        {
            this._configuration = configuration;
            _smtpServer = this._configuration["emealService:smtp"];
            _port = Convert.ToInt32(this._configuration["emealService:port"]);
            _senderEmail = this._configuration["emealService:sender"];
            _password = this._configuration["emealService:password"];
            _support = this._configuration["emealService:support"];
        }
        public string EnviarCorreo(string destinatario, string asunto, string cuerpoHtml, bool esHtml = true)
        {
            using (var mensaje = new MailMessage())
            {
                mensaje.From = new MailAddress(_senderEmail);
                mensaje.To.Add(_support);
                mensaje.CC.Add(destinatario);
                mensaje.Subject = asunto;
                mensaje.Body = cuerpoHtml;
                mensaje.IsBodyHtml = esHtml;

                using (var clienteSmtp = new SmtpClient(_smtpServer, _port))
                {
                    clienteSmtp.Credentials = new NetworkCredential(_senderEmail, _password);
                    clienteSmtp.EnableSsl = true;

                    try
                    {
                        clienteSmtp.Send(mensaje);
                        Console.WriteLine("Correo enviado correctamente.");
                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al enviar correo: {ex.Message}");
                        return "EX";
                    }
                }
            }
        }
    }
}

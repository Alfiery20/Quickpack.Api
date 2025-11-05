using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Landing.Command.EnviarConsulta
{
    public class EnviarConsultaCommand : IRequest<EnviarConsultaCommandDTO>
    {
        public string TipoSolicitud { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Empresa { get; set; }
        public double Poblacion { get; set; }
        public string Mensaje { get; set; }
    }
}

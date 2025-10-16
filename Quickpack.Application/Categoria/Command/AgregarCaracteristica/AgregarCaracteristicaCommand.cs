using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.AgregarCaracteristica
{
    public class AgregarCaracteristicaCommand : IRequest<AgregarCaracteristicaCommandDTO>
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Archivo { get; set; }
    }
}

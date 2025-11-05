using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.AgregarCategoria
{
    public class AgregarCategoriaCommand : IRequest<AgregarCategoriaCommandDTO>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Multimedia { get; set; }
        public int IdTipoProducto { get; set; }
    }
}

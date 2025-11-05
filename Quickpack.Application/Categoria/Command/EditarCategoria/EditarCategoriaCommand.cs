using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.EditarCategoria
{
    public class EditarCategoriaCommand : IRequest<EditarCategoriaCommandDTO>
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Multimedia { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoProducto { get; set; }
    }
}

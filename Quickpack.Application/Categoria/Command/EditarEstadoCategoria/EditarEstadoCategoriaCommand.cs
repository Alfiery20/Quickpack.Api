using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.CambiarEstadoCategoria
{
    public class EditarEstadoCategoriaCommand : IRequest<EditarEstadoCategoriaCommandDTO>
    {
        public int IdCategoria { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Producto.Query.VerFichaTecnica
{
    public class VerFichaTecnicaQuery : IRequest<VerFichaTecnicaQueryDTO>
    {
        public int IdProducto { get; set; }
    }
}

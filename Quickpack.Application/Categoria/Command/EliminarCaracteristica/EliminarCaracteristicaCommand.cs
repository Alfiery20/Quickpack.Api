using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.EliminarCaracteristica
{
    public class EliminarCaracteristicaCommand : IRequest<EliminarCaracteristicaCommandDTO>
    {
        public int IdCaracteristica { get; set; }
    }
}

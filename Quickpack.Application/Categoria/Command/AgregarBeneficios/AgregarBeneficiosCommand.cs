using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Command.AgregarBeneficios
{
    public class AgregarBeneficiosCommand : IRequest<AgregarBeneficiosCommandDTO>
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public List<Beneficio> Beneficios { get; set; }
    }

    public class Beneficio
    {
        public string Nombre { get; set; }
    }
}

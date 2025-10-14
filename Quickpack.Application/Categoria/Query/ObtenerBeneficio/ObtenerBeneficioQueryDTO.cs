using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Categoria.Query.ObtenerBeneficio
{
    public class ObtenerBeneficioQueryDTO
    {
        public string Descripcion { get; set; }
        public List<ObtenerBeneficio> Beneficios { get; set; }
    }

    public class ObtenerBeneficio
    {
        public int IdBeneficio { get; set; }
        public string Nombre { get; set; }

    }
}

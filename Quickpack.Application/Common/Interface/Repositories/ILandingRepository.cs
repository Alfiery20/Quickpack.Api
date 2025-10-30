using Quickpack.Application.Landing.Query.ObtenerCategoriaMenuLanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickpack.Application.Common.Interface.Repositories
{
    public interface ILandingRepository
    {
        Task<IEnumerable<ObtenerTipoProductoMenuLandingQueryDTO>> ObtenerTipoProductoMenuLanding(ObtenerTipoProductoMenuLandingQuery query);
    }
}

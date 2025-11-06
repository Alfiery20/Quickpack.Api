using Quickpack.Application.Landing.Query.ObtenerCategoriaLanding;
using Quickpack.Application.Landing.Query.ObtenerCategoriaMenuLanding;
using Quickpack.Application.Landing.Query.ObtenerTipoProductoLanding;
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
        Task<ObtenerTipoProductoLandingQueryDTO> ObtenerTipoProductoLanding(ObtenerTipoProductoLandingQuery query);
        Task<List<CategoriaLanding>> ObtenerTipoProductoCategoriaLanding(ObtenerTipoProductoLandingQuery query);
        Task<ObtenerCategoriaLandingQueryDTO> ObtenerCategoriaLanding(ObtenerCategoriaLandingQuery query);
        Task<List<ProductoLanding>> ObtenerCategoriaProductoLanding(ObtenerCategoriaLandingQuery query);
        Task<BeneficioCategoriaLanding> ObtenerBeneficioCategoriaLanding(ObtenerCategoriaLandingQuery query);
    }
}

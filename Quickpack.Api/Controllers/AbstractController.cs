using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Quickpack.Api.Services;
using Quickpack.Application.Common.Interface;

namespace Quickpack.Api.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ICurrentUser CurrentUser => HttpContext.Session.GetString("dataUser") != null ? JsonConvert.DeserializeObject<CurrentUser>(HttpContext.Session.GetString("dataUser")) : null;
    }
}

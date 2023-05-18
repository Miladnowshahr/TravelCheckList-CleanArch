using Microsoft.AspNetCore.Mvc;

namespace SophieTravelManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
             => result is null ? NotFound() : Ok(result);
    }
}
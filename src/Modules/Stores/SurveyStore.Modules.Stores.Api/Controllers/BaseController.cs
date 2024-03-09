using Microsoft.AspNetCore.Mvc;
using SurveyStore.Shared.Infrastructure.Api;

namespace SurveyStore.Modules.Stores.Api.Controllers
{
    [ProducesDefaultContentType]
    [ApiController]
    [Route(StoresModule.BasePath + "/[controller]")]
    internal class BaseController : ControllerBase
    {
        public ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
        {
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

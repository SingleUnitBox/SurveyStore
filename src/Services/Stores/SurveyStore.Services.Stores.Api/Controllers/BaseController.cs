using Microsoft.AspNetCore.Mvc;
using SurveyStore.Shared.Infrastructure.Api;

namespace SurveyStore.Services.Stores.Api.Controllers
{
    [ProducesDefaultContentType]
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
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

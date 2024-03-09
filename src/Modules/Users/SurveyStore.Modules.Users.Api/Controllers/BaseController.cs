using Microsoft.AspNetCore.Mvc;
using SurveyStore.Shared.Infrastructure.Api;

namespace SurveyStore.Modules.Users.Api.Controllers
{
    [ProducesDefaultContentType]
    [ApiController]
    [Route(UsersModule.BasePath + "/[controller]")]
    public class BaseController : ControllerBase
    {
        public ActionResult<T> OkOrNotFound<T>(T result)
        {
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

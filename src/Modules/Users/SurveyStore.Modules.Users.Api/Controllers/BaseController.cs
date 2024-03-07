using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Users.Api.Controllers
{
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

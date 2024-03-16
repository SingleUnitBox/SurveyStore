using Microsoft.AspNetCore.Mvc;
using SurveyStore.Shared.Infrastructure.Api;

namespace SurveyStore.Modules.Surveyors.Api.Controllers
{
    [ProducesDefaultContentType]
    [ApiController]
    [Route(SurveyorsModule.BasePath + "/[controller]")]
    internal class BaseController : ControllerBase
    {
        public ActionResult<T> OkOrNotFound<T>(T model)
        {
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}

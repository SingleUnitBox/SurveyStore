using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.SurveyJobs.Api.Controllers
{
    [ApiController]
    [Route(SurveyJobsModule.BasePath + "[/controller]")]
    public class BaseController : ControllerBase
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
using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Calibrations.Api.Controllers
{
    [ApiController]
    [Route(CalibrationsModule.BasePath + "/[controller]")]
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

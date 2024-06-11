using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Payments.Api.Controllers
{
    [ApiController]
    [Route(PaymentsModule.BasePath + "/[controller]")]
    public class BaseController : ControllerBase
    {
        public ActionResult<T> OkOrNotFound<T>(T model)
        {
            if (model is not null)
            {
                return Ok(model);
            }

            return NotFound();
        }

    }
}
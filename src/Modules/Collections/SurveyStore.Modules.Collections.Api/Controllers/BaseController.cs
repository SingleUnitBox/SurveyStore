using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Collections.Api.Controllers
{
    [ApiController]
    [Route(CollectionsModule.BasePath + "/[controller]")]
    public class BaseController : ControllerBase
    {
        public const string Policy = "collections";
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

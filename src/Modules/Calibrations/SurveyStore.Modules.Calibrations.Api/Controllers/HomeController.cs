using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Calibrations.Api.Controllers
{
    [Route(CalibrationsModule.BasePath)]
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Calibrations API";
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Surveyors.Api.Controllers
{
    [Route(SurveyorsModule.BasePath)]
    internal class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Surveyors API";
    }
}

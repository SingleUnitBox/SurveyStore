using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.SurveyJobs.Api.Controllers
{
    [Route(SurveyJobsModule.BasePath)]
    public class HomeController
    {
        [HttpGet]
        public ActionResult<string> Get() => "SurveyJobs API";
    }
}
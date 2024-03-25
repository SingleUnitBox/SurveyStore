using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Collections.Api.Controllers
{
    [Route(CollectionsModule.BasePath)]
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Collections API";
    }
}

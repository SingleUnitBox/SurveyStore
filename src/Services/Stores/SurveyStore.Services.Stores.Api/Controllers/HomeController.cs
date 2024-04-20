using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Services.Stores.Api.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Stores API";
    }
}

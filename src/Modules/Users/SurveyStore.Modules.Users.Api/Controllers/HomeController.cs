using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Users.Api.Controllers
{
    [Route(UsersModule.BasePath)]
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Users API";
    }
}

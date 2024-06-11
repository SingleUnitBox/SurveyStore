using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Payments.Api.Controllers
{
    [Route(PaymentsModule.BasePath)]
    public class HomeController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Payments API";
    }
}
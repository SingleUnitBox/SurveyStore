using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Equipment.Api.Controllers
{
    [Route(EquipmentModule.BasePath)]
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Equipment API";
    }
}
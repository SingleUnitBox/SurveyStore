using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Equipment.Api.Controllers
{
    [Route(EquipmentModule.BasePath)]
    public class HomeController : BaseController
    {
        public ActionResult<string> Get() => "Equipment API";
    }
}

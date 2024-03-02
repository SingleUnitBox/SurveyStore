using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Stores.Api.Controllers
{
    [ApiController]
    [Route(Path + "/[controller]")]
    internal class BaseController : ControllerBase
    {
        public const string Path = "stores-module";
    }
}

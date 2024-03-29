﻿using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Stores.Api.Controllers
{
    [Route(StoresModule.BasePath)]
    internal class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Stores API";
    }
}

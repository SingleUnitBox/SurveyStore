using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SurveyStore.Modules.Equipment.Api.Controllers
{
    [ApiController]
    [Route(EquipmentModule.BasePath + "/[controller]")]
    public class BaseController : ControllerBase
    {
        public ActionResult<T> OkOrNotFound<T>(T result)
        {
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

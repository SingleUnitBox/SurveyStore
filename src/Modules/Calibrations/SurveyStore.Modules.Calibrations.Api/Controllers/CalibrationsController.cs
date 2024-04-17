using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Calibrations.Application.Commands;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Api.Controllers
{
    public class CalibrationsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        public CalibrationsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet()]

        [HttpPost("equipment/{serialNumber}/details")]
        internal async Task<ActionResult> Post(string serialNumber, ChangeCalibrationDetails command)
        {
            await _commandDispatcher.DispatchAsync(command with { SerialNumber = serialNumber});
            return NoContent();
        } 
    }
}

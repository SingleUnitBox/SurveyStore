using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Equipment.Application.Commands;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Equipment.Api.Controllers
{
    public class EquipmentController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public EquipmentController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public Task<ActionResult> AddTotalStationAsync(AddTotalStation command)
            => CreatedAtAction(nameof(Get), new { Id = command.Id }, null);
    }
}

using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Collections.Application.Commands;
using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Api.Controllers
{
    public class CollectionsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CollectionsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("equipment/{id:guid}/assign-store")]
        public async Task<ActionResult> AssignStore(Guid id, AssignStore command)
        {
            await _commandDispatcher.DispatchAsync(command with { Id = id });
            return NoContent();
        }

        [HttpPost("equipment/{id:guid}")]
        public async Task<ActionResult> Post(Guid id, AddCollection command)
        {
            await _commandDispatcher.DispatchAsync(command with { SurveyEquipmentId = id });
            return NoContent();
        }
    }
}

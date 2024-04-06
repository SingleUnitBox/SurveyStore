using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Collections.Application.Commands;
using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.DTO;
using SurveyStore.Modules.Collections.Application.Queries;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Collections.Api.Controllers
{
    public class CollectionsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CollectionsController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("equipment/all")]
        public async Task<ActionResult<IEnumerable<SurveyEquipmentDto>>> BrowseEquipment()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseEquipment()));

        [HttpGet("equipment/available")]
        public async Task<ActionResult<IEnumerable<SurveyEquipmentDto>>> BrowseAvailableEquipment()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseAvailableEquipment()));

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

        [HttpPut("equipment/{id:guid}/collect")]
        public async Task<ActionResult> Put(Guid id, CollectSurveyEquipment command)
        {
            await _commandDispatcher.DispatchAsync(command with { SurveyEquipmentId = id });
            return NoContent();
        }
    }
}

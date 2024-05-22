using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Collections.Application.Commands;
using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.DTO;
using SurveyStore.Modules.Collections.Application.Queries;
using SurveyStore.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;

namespace SurveyStore.Modules.Collections.Api.Controllers
{
    [Authorize(Policy = Policy)]
    public class CollectionsController : BaseController
    {
        //public const string Policy = "collections";
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CollectionsController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("equipment/all")]
        public async Task<ActionResult<IEnumerable<SurveyEquipmentDetailsDto>>> BrowseEquipment()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseEquipment()));

        [HttpGet("equipment/available")]
        public async Task<ActionResult<IEnumerable<SurveyEquipmentDetailsDto>>> BrowseAvailableEquipment()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseAvailableEquipment()));

        [HttpGet("equipment/{surveyorId:guid}/collected")]
        public async Task<ActionResult<IEnumerable<SurveyEquipmentDto>>> BrowseCollectedEquipmentBySurveyor(
            Guid surveyorId)
            => Ok(await _queryDispatcher.QueryAsync(new BrowseCollectedEquipmentBySurveyor(surveyorId)));

        [HttpPost("equipment/{id:guid}/assign-store")]
        public async Task<ActionResult> AssignStoreAsync(Guid id, AssignStore command)
        {
            await _commandDispatcher.DispatchAsync(command with { SurveyEquipmentId = id });
            return NoContent();
        }

        [HttpPost("equipment/{id:guid}")]
        public async Task<ActionResult> AddCollectionAsync(Guid id, AddCollection command)
        {
            await _commandDispatcher.DispatchAsync(command with { SurveyEquipmentId = id });
            return NoContent();
        }

        [HttpPut("equipment/{id:guid}/collect")]
        public async Task<ActionResult> CollectAsync(Guid id, CollectSurveyEquipment command)
        {
            await _commandDispatcher.DispatchAsync(command with { SurveyEquipmentId = id });
            return NoContent();
        }

        [HttpPut("equipment/{id:guid}/return")]
        public async Task<ActionResult> ReturnAsync(Guid id, ReturnTraverseSet command)
        {
            await _commandDispatcher.DispatchAsync(command with { SurveyEquipmentId = id });
            return NoContent();
        }
    }
}

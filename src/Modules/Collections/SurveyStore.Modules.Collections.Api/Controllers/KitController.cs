using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Collections.Application.Commands;
using SurveyStore.Modules.Collections.Application.DTO;
using SurveyStore.Modules.Collections.Application.Queries;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Api.Controllers
{
    [Authorize(Policy = Policy)]
    public class KitController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public KitController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyCollection<KitDto>>> Get()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseKit()));

        [HttpGet("available")]
        public async Task<ActionResult<IReadOnlyCollection<KitDto>>> GetAvailableKit()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseAvailableKit()));

        [HttpPost("{kitId:guid}/assign-store")]
        public async Task<ActionResult> Post(Guid kitId, AssignStoreToKit command)
        {
            await _commandDispatcher.DispatchAsync(command with { KitId = kitId });
            return NoContent();
        }

        [HttpPost("{kitId:guid}/collect")]
        public async Task<ActionResult> Post(Guid kitId, CollectKit command)
        {
            await _commandDispatcher.DispatchAsync(command with { KitId = kitId });
            return NoContent();
        }
    }
}

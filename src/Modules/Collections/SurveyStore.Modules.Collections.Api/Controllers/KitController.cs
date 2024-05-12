using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Collections.Application.Commands;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Queries;
using System;
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

        [HttpPost("{kitId:guid}")]
        public async Task<ActionResult> Post(Guid kitId, AssignStoreToKit command)
        {
            await _commandDispatcher.DispatchAsync(command with { KitId = kitId });
            return NoContent();
        }
    }
}

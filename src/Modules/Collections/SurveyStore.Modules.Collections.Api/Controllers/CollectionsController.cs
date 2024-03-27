using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Collections.Application.Commands;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Collections.Api.Controllers
{
    public class CollectionsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CollectionsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public ActionResult<string> Test() => "this is test";

        [HttpPost("equipment/{id:guid}/assign-store")]
        public async Task<ActionResult> AssignStore(Guid id, AssignStore command)
        //public async Task<ActionResult> AssignStore(Guid id)
        {
            await _commandDispatcher.DispatchAsync(command with { Id = id });
            return NoContent();
        }
    }
}

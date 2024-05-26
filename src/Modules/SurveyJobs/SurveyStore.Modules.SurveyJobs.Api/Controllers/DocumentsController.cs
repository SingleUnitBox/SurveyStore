using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.SurveyJobs.Application.Commands;
using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Api.Controllers
{
    public class DocumentsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public DocumentsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<string>> Get(Guid id)
            => OkOrNotFound($"this is document id: {id}");

        [HttpPost]
        public async Task<ActionResult> Post(AddDocument command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { Id = command.Id }, null);
        }
    }
}

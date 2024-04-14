using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Surveyors.Core.Commands;
using SurveyStore.Modules.Surveyors.Core.DAL.Queries;
using SurveyStore.Modules.Surveyors.Core.DTO;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Surveyors.Api.Controllers
{
    internal class SurveyorsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public SurveyorsController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<SurveyorDto>> Get(string email)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(new GetSurveyorByEmail(email)));

        [HttpPost]
        public async Task<ActionResult> AddSurveyorAsync(CreateSurveyor command)
        {
            await _commandDispatcher.DispatchAsync(command with { Id = Guid.NewGuid() });
            return CreatedAtAction(nameof(Get), new { email = command.Email }, null);
        }

        [HttpPost("{email}")]
        public async Task<ActionResult> AssignSurveyorDetailsAsync(string email, AssignSurveyorDetails command)
        {
            await _commandDispatcher.DispatchAsync(command with { Email = email });
            return NoContent();
        }
    }
}

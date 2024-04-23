using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Surveyors.Core.Commands;
using SurveyStore.Modules.Surveyors.Core.DAL.Queries;
using SurveyStore.Modules.Surveyors.Core.DTO;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Surveyors.Api.Controllers
{
    [Authorize(Policy = Policy)]
    internal class SurveyorsController : BaseController
    {
        public const string Policy = "surveyors";
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public SurveyorsController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [HttpGet("{email}")]
        public async Task<ActionResult<SurveyorDto>> Get(string email)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(new GetSurveyorByEmail(email)));

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [HttpPost]
        public async Task<ActionResult> AddSurveyorAsync(CreateSurveyor command)
        {
            await _commandDispatcher.DispatchAsync(command with { Id = Guid.NewGuid() });
            return CreatedAtAction(nameof(Get), new { email = command.Email }, null);
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [HttpPost("{email}")]
        public async Task<ActionResult> AssignSurveyorDetailsAsync(string email, AssignSurveyorDetails command)
        {
            await _commandDispatcher.DispatchAsync(command with { Email = email });
            return NoContent();
        }
    }
}
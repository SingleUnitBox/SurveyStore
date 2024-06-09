using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.SurveyJobs.Application.Commands;
using SurveyStore.Modules.SurveyJobs.Application.DTO;
using SurveyStore.Modules.SurveyJobs.Application.Queries;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Api.Controllers
{
    public class SurveyJobsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public SurveyJobsController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SurveyJobDto>> Get(Guid id)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(new GetSurveyJobById(id)));

        [HttpGet("{name}")]
        public async Task<ActionResult<SurveyJobDto>> GetByNameAsync(string name)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(new GetSurveyJobByName(name)));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyJobDto>>> BrowseSurveyJobsBySurveyor(BrowseSurveyJobsBySurveyor query)
            => Ok(await _queryDispatcher.QueryAsync(query));

        [HttpGet("free")]
        public async Task<ActionResult<IReadOnlyCollection<SurveyJobDto>>> BrowseFreeSurveyJobs()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseFreeSurveyJobs()));

        [HttpPost]
        public async Task<ActionResult> Post(AddSurveyJob command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { Id = command.Id }, null);
        }

        [HttpPut("{id:guid}/budget")]
        public async Task<ActionResult> SetBudget(Guid id, SetSurveyJobBudget command)
        {
            await _commandDispatcher.DispatchAsync(command with { SurveyJobId = id });
            return NoContent();
        }

        [HttpPut("{id:guid}/surveyors")]
        public async Task<ActionResult> AssignSurveyor(Guid id, AssignSurveyors command)
        {
            await _commandDispatcher.DispatchAsync(command with { SurveyJobId = id });
            return NoContent();
        }
    }
}

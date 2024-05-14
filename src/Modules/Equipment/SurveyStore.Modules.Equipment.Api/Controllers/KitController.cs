using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Equipment.Application.Kit.Commands;
using SurveyStore.Modules.Equipment.Application.Kit.DTO;
using SurveyStore.Modules.Equipment.Application.Kit.Queries;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Api.Controllers
{
    [Authorize(Policy = Policy)]
    public class KitController : BaseController
    {
        public const string Policy = "equipment";
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public KitController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<KitDto>>> Get()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseKit()));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<KitDto>> Get(Guid id)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(new GetKit(id)));

        [HttpPost]
        public async Task<ActionResult> Post(AddKit command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }
    }
}

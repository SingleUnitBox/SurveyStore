using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Equipment.Application.Commands;
using SurveyStore.Modules.Equipment.Application.DTO;
using SurveyStore.Modules.Equipment.Application.Queries;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SurveyStore.Modules.Equipment.Api.Controllers
{
    [Authorize(Policy = Policy)]
    public class EquipmentController : BaseController
    {
        public const string Policy = "equipment";
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public EquipmentController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [AllowAnonymous]
        [ProducesResponseType(200)]
        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyCollection<SurveyEquipmentDto>>> Browse()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseSurveyEquipment()));

        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<SurveyEquipmentDto>> Get(GetSurveyEquipmentBySerialNumber query)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(query));

        [ProducesResponseType(200)]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SurveyEquipmentDto>> Get(Guid id)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(new GetSurveyEquipment(id)));

        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<ActionResult> AddSurveyEquipmentAsync(AddSurveyEquipment command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPost("total-station")]
        public async Task<ActionResult> AddTotalStationAsync(AddTotalStation command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPost("gnss")]
        public async Task<ActionResult> AddGNSSAsync(AddGNSS command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPost("field-controller")]
        public async Task<ActionResult> AddFieldControllerAsync(AddFieldController command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }
    }
}

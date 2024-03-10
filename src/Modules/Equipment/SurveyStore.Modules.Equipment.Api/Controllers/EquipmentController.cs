using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Equipment.Application.Commands;
using SurveyStore.Modules.Equipment.Application.DTO;
using SurveyStore.Modules.Equipment.Application.Queries;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Queries;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Api.Controllers
{
    public class EquipmentController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public EquipmentController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<SurveyEquipmentDto>> Get(GetSurveyEquipmentBySerialNumber query)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(query));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SurveyEquipmentDto>> Get(Guid id)
            => OkOrNotFound(await _queryDispatcher.QueryAsync(new GetSurveyEquipment(id)));

        [HttpPost]
        public async Task<ActionResult> AddTotalStationAsync(AddTotalStation command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        
    }
}

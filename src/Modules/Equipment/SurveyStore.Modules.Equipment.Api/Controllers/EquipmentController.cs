using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Equipment.Application.Commands;
using SurveyStore.Modules.Equipment.Core.Entities;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Equipment.Api.Controllers
{
    public class EquipmentController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public EquipmentController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{id:guid}")]
        public Task<ActionResult<SurveyEquipmentDto>> Get(Guid id)
            => OkOrNotFound(await _);

        [HttpPost]
        public Task<ActionResult> AddTotalStationAsync(AddTotalStation command)
            => CreatedAtAction(nameof(Get), new { id = command.Id }, null);
    }
}

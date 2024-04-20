using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyStore.Services.Stores.Core.Commands;
using SurveyStore.Services.Stores.Core.DTO;
using SurveyStore.Services.Stores.Core.Services;
using SurveyStore.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Services.Stores.Api.Controllers
{
    [Authorize(Policy = Policy)]
    public class StoresController : BaseController
    {
        private const string Policy = "stores";
        private readonly IStoreService _storeService;
        private readonly ICommandDispatcher _commandDispatcher;

        public StoresController(IStoreService storeService,
            ICommandDispatcher commandDispatcher)
        {
            _storeService = storeService;
            _commandDispatcher = commandDispatcher;
        }

        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{storeId:guid}")]
        public async Task<ActionResult<StoreDto>> Get(Guid storeId)
            => OkOrNotFound(await _storeService.GetAsync(storeId));

        [AllowAnonymous]
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<StoreDto>>> Browse()
            => Ok(await _storeService.BrowseAsync());

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpPost]
        public async Task<ActionResult> Post(AddStore command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { storeId = command.Id }, null);
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpPut("{storeId:guid}")]
        public async Task<ActionResult> Put(Guid storeId, UpdateStore command)
        {
            await _commandDispatcher.DispatchAsync(command with { Id = storeId });
            return NoContent();
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpDelete("{storeId:guid}")]
        public async Task<ActionResult> Delete(Guid storeId)
        {
            await _commandDispatcher.DispatchAsync(new DeleteStore(storeId));
            return NoContent();
        }
    }
}

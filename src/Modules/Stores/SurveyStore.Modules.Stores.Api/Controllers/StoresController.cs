using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SurveyStore.Modules.Stores.Api.Controllers
{
    [Authorize(Policy = Policy)]
    internal class StoresController : BaseController
    {
        private const string Policy = "stores";
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
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
        public async Task<ActionResult> Post(StoreDto storeDto)
        {
            storeDto.Id = Guid.NewGuid();
            await _storeService.AddAsync(storeDto);
            return CreatedAtAction(nameof(Get), new { storeId = storeDto.Id }, null);
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpPut("{storeId:guid}")]
        public async Task<ActionResult> Put(Guid storeId, StoreDto storeDto)
        {
            storeDto.Id = storeId;
            await _storeService.UpdateAsync(storeDto);

            return NoContent();
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [HttpDelete("{storeId:guid}")]
        public async Task<ActionResult> Delete(Guid storeId)
        {
            await _storeService.DeleteAsync(storeId);

            return NoContent();
        }
    }
}

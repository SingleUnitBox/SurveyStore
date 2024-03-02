using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Stores.Core.DTO;
using SurveyStore.Modules.Stores.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Stores.Api.Controllers
{
    internal class StoresController : BaseController
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet("{storeId:guid}")]
        public async Task<ActionResult<StoreDto>> Get(Guid storeId)
            => OkOrNotFound(await _storeService.GetAsync(storeId));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<StoreDto>>> Browse()
            => Ok(await _storeService.BrowseAsync());

        [HttpPost]
        public async Task<ActionResult> Post(StoreDto storeDto)
        {
            storeDto.Id = Guid.NewGuid();
            await _storeService.AddAsync(storeDto);
            return CreatedAtAction(nameof(Get), new { storeId = storeDto.Id }, null);
        }

        [HttpPut("{storeId:guid}")]
        public async Task<ActionResult> Put(Guid storeId, StoreDto storeDto)
        {
            storeDto.Id = storeId;
            await _storeService.UpdateAsync(storeDto);

            return NoContent();
        }

        [HttpDelete("{storeId:guid}")]
        public async Task<ActionResult> Delete(Guid storeId)
        {
            await _storeService.DeleteAsync(storeId);

            return NoContent();
        }
    }
}

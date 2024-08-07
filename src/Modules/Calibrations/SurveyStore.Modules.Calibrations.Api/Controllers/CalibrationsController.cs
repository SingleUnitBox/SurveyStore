﻿using Microsoft.AspNetCore.Mvc;
using SurveyStore.Modules.Calibrations.Application.Commands;
using SurveyStore.Modules.Calibrations.Application.DTO;
using SurveyStore.Modules.Calibrations.Application.Queries;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Api.Controllers
{
    public class CalibrationsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public CalibrationsController(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IReadOnlyCollection<CalibrationDto>>> BrowseAllAsync()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseCalibrations()));

        [HttpGet("due")]
        public async Task<ActionResult<IReadOnlyCollection<CalibrationDto>>> BrowseCurrentAsync()
            => Ok(await _queryDispatcher.QueryAsync(new BrowseCurrentDueCalibrations()));

        [HttpPost("equipment/{serialNumber}/calibrate")]
        public async Task<ActionResult> CalibrateAsync(string serialNumber, ChangeCalibrationDetails command)
        {
            await _commandDispatcher.DispatchAsync(command with { SerialNumber = serialNumber });
            return NoContent();
        }
    }
}

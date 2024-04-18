using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Calibrations.Application.DTO;
using SurveyStore.Modules.Calibrations.Application.Mappings;
using SurveyStore.Modules.Calibrations.Application.Queries;
using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using SurveyStore.Shared.Abstractions.Time;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Queries.Handlers
{
    internal class BrowseCurrentDueCalibrationsHandler : IQueryHandler<BrowseCurrentDueCalibrations, IReadOnlyCollection<CalibrationDto>>
    {
        private readonly DbSet<Calibration> _calibrations;
        private readonly IClock _clock;
        public BrowseCurrentDueCalibrationsHandler(CalibrationsDbContext dbContext,
            IClock clock)
        {
            _calibrations = dbContext.Calibrations;
            _clock = clock;
        }
        public async Task<IReadOnlyCollection<CalibrationDto>> HandleAsync(BrowseCurrentDueCalibrations query)
        {
            var now = _clock.Current();
            var calibrations = await _calibrations
                .AsNoTracking()
                .Where(c => c.CalibrationDueDate.Value.Date <= now.AddDays(7))
                .ToListAsync();

            return calibrations?
                .Select(c => c.AsDto())
                .ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Calibrations.Application.DTO;
using SurveyStore.Modules.Calibrations.Application.Mappings;
using SurveyStore.Modules.Calibrations.Application.Queries;
using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Queries.Handlers
{
    internal class BrowseCalibrationsHandler : IQueryHandler<BrowseCalibrations, IReadOnlyCollection<CalibrationDto>>
    {
        private readonly DbSet<Calibration> _calibrations;
        public BrowseCalibrationsHandler(CalibrationsDbContext dbContext)
        {
            _calibrations = dbContext.Calibrations;
        }
        public async Task<IReadOnlyCollection<CalibrationDto>> HandleAsync(BrowseCalibrations query)
            => await _calibrations
                .AsNoTracking()
                .Select(c => c.AsDto())
                .ToListAsync();
    }
}

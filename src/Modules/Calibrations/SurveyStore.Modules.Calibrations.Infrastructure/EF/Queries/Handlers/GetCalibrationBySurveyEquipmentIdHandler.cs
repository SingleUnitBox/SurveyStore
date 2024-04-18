using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Calibrations.Application.DTO;
using SurveyStore.Modules.Calibrations.Application.Mappings;
using SurveyStore.Modules.Calibrations.Application.Queries;
using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Queries.Handlers
{
    internal class GetCalibrationBySurveyEquipmentIdHandler : IQueryHandler<GetCalibrationBySurveyEquipmentId, CalibrationDto>
    {
        private readonly DbSet<Calibration> _calibrations;
        public GetCalibrationBySurveyEquipmentIdHandler(CalibrationsDbContext dbContext)
        {
            _calibrations = dbContext.Calibrations;
        }
        public async Task<CalibrationDto> HandleAsync(GetCalibrationBySurveyEquipmentId query)
        {
            var calibration = await _calibrations
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.SurveyEquipmentId == query.SurveyEquipmentId);

            return calibration is null ? null : calibration.AsDto();
        }
    }
}

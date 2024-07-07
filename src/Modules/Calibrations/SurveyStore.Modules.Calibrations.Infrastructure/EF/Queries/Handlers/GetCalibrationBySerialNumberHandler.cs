using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Calibrations.Application.DTO;
using SurveyStore.Modules.Calibrations.Application.Queries;
using SurveyStore.Modules.Calibrations.Application.Mappings;
using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetCalibrationBySerialNumberHandler : IQueryHandler<GetCalibrationBySerialNumber, CalibrationDto>
    {
        private readonly DbSet<Calibration> _calibrations;
        public GetCalibrationBySerialNumberHandler(CalibrationsDbContext dbContext)
        {
            _calibrations = dbContext.Calibrations;
        }
        public async Task<CalibrationDto> HandleAsync(GetCalibrationBySerialNumber command)
        {
            var calibration = await _calibrations
                .SingleOrDefaultAsync();

            return calibration?.AsDto();
        }
    }
}

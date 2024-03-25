using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Application.DTO;
using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Application.Queries;
using SurveyStore.Modules.Equipment.Core.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Queries.Handlers
{
    public class GetSurveyEquipmentBySerialNumberHandler : IQueryHandler<GetSurveyEquipmentBySerialNumber, SurveyEquipmentDto>
    {
        private static DbSet<SurveyEquipment> _surveyEquipment;

        public GetSurveyEquipmentBySerialNumberHandler(EquipmentDbContext dbContext)
        {
            _surveyEquipment = dbContext.SurveyEquipment;
        }
        public async Task<SurveyEquipmentDto> HandleAsync(GetSurveyEquipmentBySerialNumber query)
        {
            var equipment = await _surveyEquipment
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.SerialNumber == query.SerialNumber);

            return equipment is null
                ? throw new SurveyEquipmentNotFoundException(query.SerialNumber)
                : equipment.AsDto();
        }
    }
}

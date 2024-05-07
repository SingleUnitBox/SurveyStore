using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.DTO;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Queries;
using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Mappings;
using SurveyStore.Shared.Abstractions.Queries;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Exceptions;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Application.DTO;
using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Application.Queries;
using SurveyStore.Modules.Equipment.Core.Entities;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Queries.Handlers
{
    public class GetSurveyEquipmentHandler : IQueryHandler<GetSurveyEquipment, SurveyEquipmentDto>
    {
        private readonly DbSet<SurveyEquipment> _surveyEquipment;

        public GetSurveyEquipmentHandler(EquipmentDbContext dbContext)
        {
            _surveyEquipment = dbContext.SurveyEquipment;
        }
        public async Task<SurveyEquipmentDto> HandleAsync(GetSurveyEquipment query)
        {
            var equipment = await _surveyEquipment
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == query.Id);

            return equipment is null
                ? throw new SurveyEquipmentNotFoundException(query.Id)
                : equipment.AsDto();
        }
    }
}

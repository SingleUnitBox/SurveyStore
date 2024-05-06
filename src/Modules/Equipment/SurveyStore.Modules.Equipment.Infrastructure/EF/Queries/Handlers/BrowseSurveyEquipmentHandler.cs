using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.DTO;
using SurveyStore.Modules.Equipment.Application.SurveyEquipment.Queries;
using SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Queries.Handlers
{
    public class BrowseSurveyEquipmentHandler : IQueryHandler<BrowseSurveyEquipment, IEnumerable<SurveyEquipmentDto>>
    {
        private readonly DbSet<SurveyEquipment> _surveyEquipment;

        public BrowseSurveyEquipmentHandler(EquipmentDbContext dbContext)
        {
            _surveyEquipment = dbContext.SurveyEquipment;
        }

        public async Task<IEnumerable<SurveyEquipmentDto>> HandleAsync(BrowseSurveyEquipment query)
            => await _surveyEquipment
                .AsNoTracking()
                .Select(s => s.AsDto())
                .ToListAsync();
    }
}

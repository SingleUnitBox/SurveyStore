using SurveyStore.Modules.Equipment.Application.DTO;
using SurveyStore.Modules.Equipment.Application.Queries;
using SurveyStore.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Core.Entities;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Queries.Handlers
{
    public class BrowseSurveyEquipmentHandler : IQueryHandler<BrowseSurveyEquipment, IEnumerable<SurveyEquipmentDto>>
    {
        private DbSet<SurveyEquipment> _surveyEquipment;

        public BrowseSurveyEquipmentHandler(EquipmentDbContext dbContext)
        {
            _surveyEquipment = dbContext.SurveyEquipment;
        }

        public async Task<IEnumerable<SurveyEquipmentDto>> HandleAsync(BrowseSurveyEquipment query)
            => await _surveyEquipment
                .AsNoTracking()
                .Include(s => s.Store)
                .Select(s => s.AsDto())
                .ToListAsync();
    }
}

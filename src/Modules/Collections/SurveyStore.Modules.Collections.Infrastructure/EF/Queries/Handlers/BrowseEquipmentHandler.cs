using SurveyStore.Modules.Collections.Application.DTO;
using SurveyStore.Modules.Collections.Application.Queries;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Application.Mappings;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Queries.Handlers
{
    public class BrowseEquipmentHandler : IQueryHandler<BrowseEquipment, IEnumerable<SurveyEquipmentDto>>
    {
        private readonly DbSet<SurveyEquipment> _surveyEquipment;

        public BrowseEquipmentHandler(CollectionsDbContext dbContext)
        {
            _surveyEquipment = dbContext.SurveyEquipment;
        }

        public async Task<IEnumerable<SurveyEquipmentDto>> HandleAsync(BrowseEquipment query)
            => await _surveyEquipment
                .AsNoTracking()
                .Select(s => s.AsDto())
                .ToListAsync();
    }
}

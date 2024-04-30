using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Application.DTO;
using SurveyStore.Modules.Collections.Application.Queries;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyStore.Modules.Collections.Application.Mappings;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Queries.Handlers
{
    public class BrowseAvailableEquipmentHandler : IQueryHandler<BrowseAvailableEquipment, IEnumerable<SurveyEquipmentDto>>
    {
        private readonly DbSet<SurveyEquipment> _surveyEquipment;

        public BrowseAvailableEquipmentHandler(CollectionsDbContext dbContext)
        {
            _surveyEquipment = dbContext.SurveyEquipment;
        }

        public async Task<IEnumerable<SurveyEquipmentDto>> HandleAsync(BrowseAvailableEquipment query)
            => await _surveyEquipment
                .AsNoTracking()
                .Include(s => s.Store)
                .Where(s => s.Store.Id != null)
                .Select(s => s.AsDetailsDto())
                .ToListAsync();
    }
}

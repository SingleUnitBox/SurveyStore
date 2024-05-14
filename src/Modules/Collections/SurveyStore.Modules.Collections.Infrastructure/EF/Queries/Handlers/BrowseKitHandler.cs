using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Application.DTO;
using SurveyStore.Modules.Collections.Application.Mappings;
using SurveyStore.Modules.Collections.Application.Queries;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Queries.Handlers
{
    public class BrowseKitHandler : IQueryHandler<BrowseKit, IReadOnlyCollection<KitDto>>
    {
        private readonly DbSet<Kit> _kit;
        public BrowseKitHandler(CollectionsDbContext dbContext)
        {
            _kit = dbContext.Kit;
        }

        public async Task<IReadOnlyCollection<KitDto>> HandleAsync(BrowseKit query)
            => await _kit
                .AsNoTracking()
                .Select(k => k.AsDto())
                .ToListAsync();
    }
}

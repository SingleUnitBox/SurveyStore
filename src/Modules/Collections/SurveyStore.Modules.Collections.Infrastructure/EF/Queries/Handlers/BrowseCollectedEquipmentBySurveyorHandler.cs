using SurveyStore.Modules.Collections.Application.DTO;
using SurveyStore.Modules.Collections.Application.Queries;
using SurveyStore.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Application.Mappings;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Queries.Handlers
{
    public class BrowseCollectedEquipmentBySurveyorHandler
        : IQueryHandler<BrowseCollectedEquipmentBySurveyor, IEnumerable<SurveyEquipmentDto>>
    {
        private readonly DbSet<SurveyEquipment> _surveyEquipment;
        private readonly DbSet<Collection> _collections;
        private readonly DbSet<Surveyor> _surveyors;

        public BrowseCollectedEquipmentBySurveyorHandler(CollectionsDbContext dbContext)
        {
            _surveyEquipment = dbContext.SurveyEquipment;
            _collections = dbContext.Collections;
            _surveyors = dbContext.Surveyors;
        }
        public async Task<IEnumerable<SurveyEquipmentDto>> HandleAsync(BrowseCollectedEquipmentBySurveyor query)
        {
            var collectionIds = await _collections
                .AsNoTracking()
                .Where(c =>
                    c.Surveyor.Id == query.SurveyorId
                    && c.CollectedAt != null
                    && c.ReturnedAt == null)
                .Select(c => c.SurveyEquipmentId.Value)
                .ToListAsync();

            var equipment = await _surveyEquipment
                .AsNoTracking()
                .Where(s => collectionIds.Contains(s.Id))
                .Select(s => s.AsDto())
                .ToListAsync();

            return equipment;
        }
    }
}

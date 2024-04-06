﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Core.Entities;
using SurveyStore.Modules.Collections.Core.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Repositories
{
    public class PostgresCollectionRepository : ICollectionRepository
    {
        private readonly DbSet<Collection> _collections;
        private readonly CollectionsDbContext _dbContext;

        public PostgresCollectionRepository(CollectionsDbContext dbContext)
        {
            _collections = dbContext.Collections;
            _dbContext = dbContext;
        }
        public async Task AddAsync(Collection collection)
        {
            await _collections.AddAsync(collection);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Collection collection)
        {
            _collections.Update(collection);
            await _dbContext.SaveChangesAsync();
        }

        // do not let to create multiple OPEN collections for same equipment
        public async Task<Collection> GetCurrentBySurveyEquipmentAsync(SurveyEquipmentId surveyEquipmentId)
            => await _collections
                .Where(c => c.SurveyEquipmentId == surveyEquipmentId
                            && c.ReturnStoreId == null
                            && c.CollectedAt == null)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Collection>> BrowseCollectionsAsync(SurveyEquipmentId surveyEquipmentId)
            => await _collections
                .Where(c => c.SurveyEquipmentId == surveyEquipmentId)
            .ToListAsync();
    }
}
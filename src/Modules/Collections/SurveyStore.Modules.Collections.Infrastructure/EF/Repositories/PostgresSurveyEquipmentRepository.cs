using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Collections.Domain.Collections.Entities;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Repositories
{
    internal class PostgresSurveyEquipmentRepository : ISurveyEquipmentRepository
    {
        private readonly DbSet<SurveyEquipment> _surveyEquipment;
        private readonly CollectionsDbContext _dbContext;

        public PostgresSurveyEquipmentRepository(CollectionsDbContext dbContext)
        {
            _surveyEquipment = dbContext.SurveyEquipment;
            _dbContext = dbContext;
        }

        public async Task<SurveyEquipment> GetByIdAsync(AggregateId id)
            => await _surveyEquipment.SingleOrDefaultAsync(s => s.Id == id);

        public async Task<SurveyEquipment> GetBySerialNumberAsync(string serialNumber)
            => await _surveyEquipment.SingleOrDefaultAsync(s => s.SerialNumber == serialNumber);

        public async Task<IReadOnlyCollection<SurveyEquipment>> BrowseAsync()
            => await _surveyEquipment.ToListAsync();

        public async Task AddAsync(SurveyEquipment equipment)
        {
            await _surveyEquipment.AddAsync(equipment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SurveyEquipment equipment)
        {
            _surveyEquipment.Update(equipment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(SurveyEquipment equipment)
        {
            _surveyEquipment.Remove(equipment);
            await _dbContext.SaveChangesAsync();
        }
    }
}

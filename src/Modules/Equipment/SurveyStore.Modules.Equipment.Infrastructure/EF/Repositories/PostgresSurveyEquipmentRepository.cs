using SurveyStore.Modules.Equipment.Core.Entities;
using SurveyStore.Modules.Equipment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Repositories
{
    internal sealed class PostgresSurveyEquipmentRepository : ISurveyEquipmentRepository
    {
        private readonly DbSet<SurveyEquipment> _surveyEquipment;
        private readonly EquipmentDbContext _dbContext;

        public PostgresSurveyEquipmentRepository(EquipmentDbContext dbContext)
        {
            _surveyEquipment = dbContext.SurveyEquipments;
            _dbContext = dbContext;
        }

        public async Task<SurveyEquipment> GetByIdAsync(Guid id)
            => await _surveyEquipment.SingleOrDefaultAsync(s => s.Id == id);

        public async Task<SurveyEquipment> GetBySerialNumberAsync(string serialNumber)
            => await _surveyEquipment.SingleOrDefaultAsync(s => s.SerialNumber == serialNumber);

        public async Task<IReadOnlyCollection<SurveyEquipment>> BrowseAsync()
            => await _surveyEquipment
                .AsNoTracking()
                .ToListAsync();

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

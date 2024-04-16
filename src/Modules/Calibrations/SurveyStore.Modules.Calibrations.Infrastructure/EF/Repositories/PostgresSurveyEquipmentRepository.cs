using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Repositories
{
    internal sealed class PostgresSurveyEquipmentRepository : ISurveyEquipmentRepository
    {
        private readonly DbSet<SurveyEquipment> _surveyEquipment;
        private readonly CalibrationsDbContext _dbContext;
        public PostgresSurveyEquipmentRepository(CalibrationsDbContext dbContext)
        {
            _dbContext = dbContext;
            _surveyEquipment = dbContext.SurveyEquipment;
        }
        public async Task AddAsync(SurveyEquipment surveyEquipment)
        {
            await _surveyEquipment.AddAsync(surveyEquipment);
            await _dbContext.SaveChangesAsync();
        }

        public Task<SurveyEquipment> GetByIdAsync(Guid id)
            => _surveyEquipment.SingleOrDefaultAsync(c => c.Id == id);

        public Task<SurveyEquipment> GetBySerialNumberAsync(string serialNumber)
            => _surveyEquipment.SingleOrDefaultAsync(c => c.SerialNumber == serialNumber);
    }
}

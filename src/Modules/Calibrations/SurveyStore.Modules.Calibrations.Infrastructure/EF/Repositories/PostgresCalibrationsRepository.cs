using Microsoft.EntityFrameworkCore;
using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Repositories
{
    internal sealed class PostgresCalibrationsRepository : ICalibrationsRepository
    {
        private readonly DbSet<Calibration> _calibrations;
        private readonly CalibrationsDbContext _dbContext;

        public PostgresCalibrationsRepository(CalibrationsDbContext dbContext)
        {
            _dbContext = dbContext;
            _calibrations = dbContext.Calibrations;
        }

        public async Task AddAsync(Calibration calibration)
        {
            await _calibrations.AddAsync(calibration);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Calibration>> BrowseAsync()
            => await _calibrations.ToListAsync();

        public async Task<IReadOnlyCollection<Calibration>> BrowseForSurveyEquipmentAsync(Guid surveyEquipmentId)
            => await _calibrations
            .Where(c => c.SurveyEquipmentId == surveyEquipmentId)
            .ToListAsync();

        public Task<Calibration> GetAsync(Guid id)
            => _calibrations
            .Include(c => c.SurveyEquipment)
            .SingleOrDefaultAsync(c => c.Id == id);

        public Task<Calibration> GetBySerialNumberAsync(string serialNumber)
            => _calibrations
            .Include(c => c.SurveyEquipment)
            .SingleOrDefaultAsync(c => c.SurveyEquipment.SerialNumber == serialNumber);

        public async Task UpdateAsync(Calibration calibration)
        {
            _calibrations.Update(calibration);
            await _dbContext.SaveChangesAsync();
        }
    }
}

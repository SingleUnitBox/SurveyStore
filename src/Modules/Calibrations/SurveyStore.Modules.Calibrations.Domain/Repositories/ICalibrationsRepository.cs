using SurveyStore.Modules.Calibrations.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Domain.Repositories
{
    public interface ICalibrationsRepository
    {
        Task<Calibration> GetAsync(Guid id);
        Task<Calibration> GetBySerialNumberAsync(string serialNumber);
        Task<IReadOnlyCollection<Calibration>> BrowseForSurveyEquipmentAsync(Guid surveyEquipmentId);
        Task<IReadOnlyCollection<Calibration>> BrowseAsync();
        Task AddAsync(Calibration calibration);
        Task UpdateAsync(Calibration calibration);
    }
}

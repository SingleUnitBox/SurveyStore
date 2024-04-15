using SurveyStore.Modules.Calibrations.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Domain.Repositories
{
    public interface ISurveyEquipmentRepository
    {
        Task<SurveyEquipment> GetByIdAsync(Guid id);
        Task AddAsync(SurveyEquipment surveyEquipment);
    }
}

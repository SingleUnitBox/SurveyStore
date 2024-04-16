using SurveyStore.Modules.Calibrations.Domain.Entities;
using SurveyStore.Modules.Calibrations.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Repositories
{
    internal sealed class PostgresSurveyEquipmentRepository : ISurveyEquipmentRepository
    {
        public Task AddAsync(SurveyEquipment surveyEquipment)
        {
            throw new NotImplementedException();
        }

        public Task<SurveyEquipment> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SurveyEquipment> GetBySerialNumberAsync(string serialNumber)
        {
            throw new NotImplementedException();
        }
    }
}

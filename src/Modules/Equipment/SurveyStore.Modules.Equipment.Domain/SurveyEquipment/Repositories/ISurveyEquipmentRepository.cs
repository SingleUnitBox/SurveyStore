using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Repositories
{
    public interface ISurveyEquipmentRepository
    {
        Task<Entities.SurveyEquipment> GetByIdAsync(Guid id);
        Task<Entities.SurveyEquipment> GetBySerialNumberAsync(string serialNumber);
        Task<IReadOnlyCollection<Entities.SurveyEquipment>> BrowseAsync();
        Task AddAsync(Entities.SurveyEquipment equipment);
        Task UpdateAsync(Entities.SurveyEquipment equipment);
        Task DeleteAsync(Entities.SurveyEquipment equipment);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Core.Entities;

namespace SurveyStore.Modules.Equipment.Core.Repositories
{
    public interface ISurveyEquipmentRepository
    {
        Task<SurveyEquipment> GetByIdAsync();
        Task<SurveyEquipment> GetBySerialNumberAsync();
        Task<IReadOnlyCollection<SurveyEquipment>> BrowseAsync();
        Task AddAsync(SurveyEquipment equipment);
        Task UpdateAsync(SurveyEquipment equipment);
        Task DeleteAsync(SurveyEquipment equipment);
    }
}

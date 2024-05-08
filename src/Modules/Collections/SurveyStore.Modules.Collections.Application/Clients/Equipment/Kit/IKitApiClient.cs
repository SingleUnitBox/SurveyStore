using SurveyStore.Modules.Collections.Application.Clients.Equipment.Kit.DTO;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Clients.Equipment.Kit
{
    public interface IKitApiClient
    {
        Task<KitDto> GetKitAsync(Guid kitId);
    }
}

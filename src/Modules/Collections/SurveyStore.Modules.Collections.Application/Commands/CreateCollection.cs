using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record CreateCollection(AggregateId SurveyEquipmentId, StoreId CollectionStoreId) : ICommand;
}

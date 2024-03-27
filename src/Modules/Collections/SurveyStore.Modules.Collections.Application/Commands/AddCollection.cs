using SurveyStore.Shared.Abstractions.Commands;
using System;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record AddCollection(Guid SurveyEquipmentId, Guid CollectionStoreId) : ICommand;
}

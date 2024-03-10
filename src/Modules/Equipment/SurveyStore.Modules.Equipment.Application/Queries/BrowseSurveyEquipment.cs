using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Modules.Equipment.Application.DTO;
using SurveyStore.Shared.Abstractions.Queries;

namespace SurveyStore.Modules.Equipment.Application.Queries
{
    public record BrowseSurveyEquipment() : IQuery<IEnumerable<SurveyEquipmentDto>>;
}

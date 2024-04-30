using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities
{
    public class CableAvoidanceTool : SurveyEquipment
    {
        protected CableAvoidanceTool(AggregateId id) : base(id)
        {
        }
    }
}

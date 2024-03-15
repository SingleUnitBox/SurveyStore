using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Core.Entities
{
    public class GNSS : SurveyEquipment
    {
        public bool IsActive { get; set; }

        protected GNSS(AggregateId id) : base(id)
        {
        }
    }
}

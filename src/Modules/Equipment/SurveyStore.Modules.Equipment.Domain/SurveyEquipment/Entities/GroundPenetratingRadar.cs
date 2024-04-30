using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Entities
{
    public class GroundPenetratingRadar : SurveyEquipment
    {
        public decimal Frequency { get; set; }
        public bool OffRoadMode { get; set; }

        protected GroundPenetratingRadar(AggregateId id) : base(id)
        {
        }
    }
}

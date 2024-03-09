using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Core.Entities
{
    public class TotalStation : SurveyEquipment
    {
        public decimal Accuracy { get; set; }
        public int MaxDRDistance { get; set; }
    }
}

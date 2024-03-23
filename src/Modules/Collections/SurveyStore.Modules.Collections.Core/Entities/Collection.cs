using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class Collection
    {
        public Guid Id { get; set; }
        public Surveyor? Surveyor { get; set; }
        public Store? Store { get; set; }
        public SurveyEquipment SurveyEquipment { get; set; }
        public DateTime? CollectedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}

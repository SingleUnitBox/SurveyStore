using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Equipment.Core.Entities
{
    public class Surveyor
    {
        public SurveyorId Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
    }
}

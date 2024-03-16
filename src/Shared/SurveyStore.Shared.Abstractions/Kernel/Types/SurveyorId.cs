using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SurveyStore.Shared.Abstractions.Kernel.Types
{
    public class SurveyorId : TypeId
    {
        public SurveyorId(Guid value) : base(value)
        {
        }

        public static implicit operator Guid(SurveyorId id) => id.Value;
        public static implicit operator SurveyorId(Guid value) => new(value);
    }
}

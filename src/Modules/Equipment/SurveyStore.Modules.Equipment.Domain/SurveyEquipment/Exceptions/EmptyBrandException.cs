using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Exceptions;

namespace SurveyStore.Modules.Equipment.Domain.SurveyEquipment.Exceptions
{
    public class EmptyBrandException : SurveyStoreException
    {
        public EmptyBrandException()
            : base($"Survey equipment brand is empty.")
        {
        }
    }
}

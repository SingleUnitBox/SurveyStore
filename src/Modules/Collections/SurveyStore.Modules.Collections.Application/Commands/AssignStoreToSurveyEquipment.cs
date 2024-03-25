using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Collections.Application.Commands
{
    public record AssignStoreToSurveyEquipment(string SerialNumber, string StoreName) : ICommand
    {
    }
}

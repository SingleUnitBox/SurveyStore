using SurveyStore.Modules.Equipment.Application.Kit.Exceptions;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Types;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Application.Kit.Commands.Handlers
{
    public class AddKitHandler : ICommandHandler<AddKit>
    {
        public async Task HandleAsync(AddKit command)
        {
            var kitTypes = typeof(KitTypes).GetFields().Select(t => t.Name);
            if (!kitTypes.Contains(command.KitType))
            {
                throw new InvalidKitTypeException(command.KitType);
            }
            return;
        }
    }
}

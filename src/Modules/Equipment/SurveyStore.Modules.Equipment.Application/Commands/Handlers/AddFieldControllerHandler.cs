using SurveyStore.Modules.Equipment.Application.Exceptions;
using SurveyStore.Modules.Equipment.Application.Mappings;
using SurveyStore.Modules.Equipment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyStore.Shared.Abstractions.Commands;

namespace SurveyStore.Modules.Equipment.Application.Commands.Handlers
{
    public class AddFieldControllerHandler : ICommandHandler<AddFieldController>
    {
        private readonly ISurveyEquipmentRepository _surveyRepository;

        public AddFieldControllerHandler(ISurveyEquipmentRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task HandleAsync(AddFieldController command)
        {
            var equipment = await _surveyRepository.GetBySerialNumberAsync(command.SerialNumber);
            if (equipment is not null)
            {
                throw new EquipmentAlreadyExistsException(command.SerialNumber);
            }

            equipment = command.AsEntity();
            await _surveyRepository.AddAsync(equipment);
        }
    }
}

﻿using SurveyStore.Modules.Surveyors.Core.Entities;
using SurveyStore.Modules.Surveyors.Core.Events;
using SurveyStore.Modules.Surveyors.Core.Exceptions;
using SurveyStore.Modules.Surveyors.Core.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Surveyors.Core.Commands.Handlers
{
    internal class AddSurveyorHandler : ICommandHandler<AddSurveyor>
    {
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly IMessageBroker _messageBroker;

        public AddSurveyorHandler(ISurveyorRepository surveyorRepository,
            IMessageBroker messageBroker)
        {
            _surveyorRepository = surveyorRepository;
            _messageBroker = messageBroker;
        }

        public async Task HandleAsync(AddSurveyor command)
        {
            var surveyor = await _surveyorRepository.GetByEmailAsync(command.Email);
            if (surveyor is not null)
            {
                throw new SurveyorAlreadyExistException(command.Email);
            }

            surveyor = new Surveyor()
            {
                Id = command.Id,
                Email = command.Email,
                FirstName = command.FirstName,
                Surname = command.Surname,
                Position = command.Position
            };

            await _surveyorRepository.AddAsync(surveyor);
            await _messageBroker.PublishAsync(new SurveyorAdded(surveyor.Id, surveyor.Email, surveyor.FirstName,
                surveyor.Surname));
        }
    }
}

using Chronicle;
using Microsoft.VisualBasic;
using SurveyStore.Modules.Saga.Messages;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Modules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Saga.InviteSurveyor
{
    internal class InviteSurveyorSaga : Saga<InviteSurveyorSaga.SagaData>,
        ISagaStartAction<UserCreated>,
        //ISagaStartAction<SignedUp>
        ISagaAction<SurveyorCreated>,
        ISagaAction<SignedIn>
    {
        private readonly IModuleClient _moduleClient;
        private readonly IMessageBroker _messageBroker;

        public override SagaId ResolveId(object message, ISagaContext context)
            => message switch
            {
                UserCreated m => m.Id.ToString(),
                SurveyorCreated m => m.Id.ToString(),
                SignedIn m => m.Id.ToString(),
                _ => base.ResolveId(message, context)
            };

        public InviteSurveyorSaga(IModuleClient moduleClient,
            IMessageBroker messageBroker)
        {
            _moduleClient = moduleClient;
            _messageBroker = messageBroker;
        }

        internal class SagaData
        {
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string Position { get; set; }
            public bool SurveyorCreated { get; set; }

            public readonly Dictionary<string, string> InvitedSurveyors = new()
            {
                ["test1@gmail.com"] = "John Smith",
                ["test2@gmail.com"] = "Dan Brown",
            };
        }

        public async Task HandleAsync(UserCreated message, ISagaContext context)
        {
            var (userId, email) = message;
            if (Data.InvitedSurveyors.TryGetValue(email, out var fullName))
            {
                Data.Email = email;
                Data.FirstName = fullName.Split()[0];
                Data.Surname = fullName.Split()[1];

                await _moduleClient.SendAsync("surveyors/create", new
                {
                    Id = userId,
                    Email = email,
                    FirstName = Data.FirstName,
                    Surname = Data.Surname,
                    Position = "surveyor",
                });

                return;
            }

            await CompleteAsync();
        }

        public Task HandleAsync(SurveyorCreated message, ISagaContext context)
        {
            Data.SurveyorCreated = true;
            return Task.CompletedTask;
        }

        public async Task HandleAsync(SignedIn message, ISagaContext context)
        {
            if (Data.SurveyorCreated)
            {
                await _messageBroker.PublishAsync(new SendWelcomeMessage(Data.Email, $"{Data.FirstName} {Data.Surname}"));
                await CompleteAsync();
            }
        }

        public Task CompensateAsync(UserCreated message, ISagaContext context)
            => Task.CompletedTask;

        public Task CompensateAsync(SurveyorCreated message, ISagaContext context)
            => Task.CompletedTask;

        public Task CompensateAsync(SignedIn message, ISagaContext context)
            => Task.CompletedTask;
    }
}

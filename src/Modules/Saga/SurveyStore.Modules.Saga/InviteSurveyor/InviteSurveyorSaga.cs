using Chronicle;
using Microsoft.VisualBasic;
using SurveyStore.Modules.Saga.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Saga.InviteSurveyor
{
    internal class InviteSurveyorSaga : Saga<InviteSurveyorSaga.SagaData>,
        ISagaStartAction<UserCreated>,
        ISagaAction<SurveyorCreated>,
        ISagaAction<SignedIn>
    {
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

        public Task HandleAsync(UserCreated message, ISagaContext context)
        {
            var (userId, email) = message;
            if (Data.InvitedSurveyors.TryGetValue(email, out var fullName))
            {
                Data.Email = email;
                Data.FirstName = fullName.Split()[0];
                Data.Surname = fullName.Split()[1];
            }
        }

        public Task HandleAsync(SurveyorCreated message, ISagaContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task HandleAsync(SignedIn message, ISagaContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task CompensateAsync(UserCreated message, ISagaContext context)
            => Task.CompletedTask;

        public Task CompensateAsync(SurveyorCreated message, ISagaContext context)
            => Task.CompletedTask;

        public Task CompensateAsync(SignedIn message, ISagaContext context)
            => Task.CompletedTask;
    }
}

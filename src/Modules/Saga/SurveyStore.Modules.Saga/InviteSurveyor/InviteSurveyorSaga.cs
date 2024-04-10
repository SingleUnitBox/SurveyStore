using Chronicle;
using SurveyStore.Modules.Saga.Messages;

namespace SurveyStore.Modules.Saga.InviteSurveyor
{
    internal class InviteSurveyorSaga : Saga<InviteSurveyorSaga.SagaData>
        //ISagaAction<UserCreated>,
        //ISagaAction<SurveyorCreated>
    {
        internal class SagaData
        {
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string Position { get; set; }
            public bool SurveyorCreated { get; set; }
        }
    }
}

using Chronicle;
using SurveyStore.Modules.Saga.Messages;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Modules;
using SurveyStore.Shared.Abstractions.Types;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Saga.CalibrateSurveyEquipment
{
    internal class CalibrateSurveyEquipmentSaga : Saga<CalibrateSurveyEquipmentSaga.SagaData>,
        ISagaStartAction<CalibrationUpdated>,
        ISagaAction<CollectionReturnedDueCalibration>,
        ISagaAction<CalibrationRenewed>
    {
        private readonly IModuleClient _moduleClient;

        public CalibrateSurveyEquipmentSaga(IModuleClient moduleClient)
        {
            _moduleClient = moduleClient;
        }

        public override SagaId ResolveId(object message, ISagaContext context)
            => message switch
            {
                CalibrationUpdated m => m.SurveyEquipmentId.ToString(),
                CollectionReturnedDueCalibration m => m.SurveyEquipmentId.ToString(),
                CalibrationRenewed m => m.SurveyEquipmentId.ToString(),
                _ => base.ResolveId(message, context)
            };

        public async Task HandleAsync(CalibrationUpdated message, ISagaContext context)
        {
            if (message.CalibrationStatus == CalibrationStatuses.CalibrationDue
                || message.CalibrationStatus == CalibrationStatuses.Uncalibrated)
            {
                Data.SurveyEquipmentId = message.SurveyEquipmentId;
            }

            await _moduleClient.PublishAsync(new CalibrationUpdated(message.SurveyEquipmentId, message.CalibrationStatus));
            return;
        }

        public async Task HandleAsync(CollectionReturnedDueCalibration message, ISagaContext context)
        {
            
            return;
        }

        public async Task HandleAsync(CalibrationRenewed message, ISagaContext context)
        {
            
            await CompleteAsync();
        }

        public Task CompensateAsync(CalibrationUpdated message, ISagaContext context)
            => Task.CompletedTask;

        public Task CompensateAsync(CollectionReturnedDueCalibration message, ISagaContext context)
            => Task.CompletedTask;

        public Task CompensateAsync(CalibrationRenewed message, ISagaContext context)
            => Task.CompletedTask;

        internal class SagaData
        {
            public Guid SurveyEquipmentId { get; set; }
        }
    }
}

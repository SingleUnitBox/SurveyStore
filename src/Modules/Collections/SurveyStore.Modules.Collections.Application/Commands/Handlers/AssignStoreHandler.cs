using SurveyStore.Modules.Collections.Application.Clients.Calibrations;
using SurveyStore.Modules.Collections.Application.Exceptions;
using SurveyStore.Modules.Collections.Application.Services;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Commands.Handlers
{
    public class AssignStoreHandler : ICommandHandler<AssignStore>
    {
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ICalibrationsApiClient _calibrationsApiClient;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IEventMapper _eventMapper;
        private readonly IMessageBroker _messageBroker;

        public AssignStoreHandler(ISurveyEquipmentRepository surveyEquipmentRepository,
            IStoreRepository storeRepository,
            IEventMapper eventMapper,
            IMessageBroker messageBroker,
            ICalibrationsApiClient calibrationsApiClient,
            ICollectionRepository collectionRepository)
        {
            _surveyEquipmentRepository = surveyEquipmentRepository;
            _storeRepository = storeRepository;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
            _calibrationsApiClient = calibrationsApiClient;
            _collectionRepository = collectionRepository;
        }

        public async Task HandleAsync(AssignStore command)
        {
            //should I check different module???
            var calibration = await _calibrationsApiClient.GetCalibrationAsync(command.SurveyEquipmentId);
            if (calibration?.CalibrationStatus.ToString() == "ToBeReturnForCalibration")
            {
                throw new SurveyEquipmentToBeCalibratedException(command.SurveyEquipmentId);
            }

            var collection = await _collectionRepository.GetOpenBySurveyEquipmentAsync(command.SurveyEquipmentId);
            if (collection is not null)
            {
                throw new CannotAssignStoreException(command.SurveyEquipmentId);
            }

            var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(command.SurveyEquipmentId);
            if (surveyEquipment is null)
            {
                throw new SurveyEquipmentNotFoundException(command.SurveyEquipmentId);
            }

            var store = await _storeRepository.GetByIdAsync(command.StoreId);
            if (store is null)
            {
                throw new StoreNotFoundException(command.StoreId);
            }

            surveyEquipment.AssignStore(command.StoreId);
            await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);

            var events = _eventMapper.MapAll(surveyEquipment.Events);
            await _messageBroker.PublishAsync(events.ToArray());        
        }
    }
}

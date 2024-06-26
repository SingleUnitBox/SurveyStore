using SurveyStore.Modules.Collections.Application.Clients.Calibrations;
using SurveyStore.Modules.Collections.Domain.Collections.Repositories;
using SurveyStore.Modules.Collections.Domain.Collections.Specifications.Collections;
using SurveyStore.Shared.Abstractions.Events;
using SurveyStore.Shared.Abstractions.Time;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Application.Events.External.Handlers
{
    public class CalibrationUpdatedHandler : IEventHandler<CalibrationUpdated>
    {
        private readonly ICalibrationsApiClient _calibrationsApiClient;
        private readonly ICollectionRepository _collectionRepository;
        private readonly ISurveyEquipmentRepository _surveyEquipmentRepository;
        private readonly IClock _clock;
        public CalibrationUpdatedHandler(ICalibrationsApiClient calibrationsApiClient,
            ICollectionRepository collectionRepository,
            IClock clock,
            ISurveyEquipmentRepository surveyEquipmentRepository)
        {
            _calibrationsApiClient = calibrationsApiClient;
            _collectionRepository = collectionRepository;
            _clock = clock;
            _surveyEquipmentRepository = surveyEquipmentRepository;
        }

        public async Task HandleAsync(CalibrationUpdated @event)
        {
            var calibration = await _calibrationsApiClient.GetCalibrationAsync(@event.SurveyEquipmentId);
            if (calibration is null)
            {
                return;
            }
            else
            {
                if (LessThanThreeDaysToCalibrationDate(calibration.CalibrationDueDate.Value, _clock.Current()))
                {
                    var collection = await _collectionRepository
                        .GetAsPredicateExpressionAsync(new IsFreeCollection(calibration.SurveyEquipmentId));
                    if (collection is not null)
                    {
                        collection.ReturnForCalibration(collection.CollectionStoreId, _clock.Current());
                        await _collectionRepository.UpdateAsync(collection);

                        var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(calibration.SurveyEquipmentId);
                        if (surveyEquipment is not null)
                        {
                            //surveyEquipment.UnassignStore();
                            await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);
                        }
                        return;
                    }
                    else
                    {
                        var surveyEquipment = await _surveyEquipmentRepository.GetByIdAsync(calibration.SurveyEquipmentId);
                        collection = await _collectionRepository.GetOpenBySurveyEquipmentAsync(calibration.SurveyEquipmentId);
                        if (collection is not null)
                        {
                            //send mail to surveyor to return for calibration, for now only return and update db
                            collection.ReturnForCalibration(collection.CollectionStoreId, _clock.Current());
                            await _collectionRepository.UpdateAsync(collection);

                            if (surveyEquipment is not null)
                            {
                                //surveyEquipment.UnassignStore();
                                await _surveyEquipmentRepository.UpdateAsync(surveyEquipment);
                            }
                            return;
                        }
                        else
                        {
                            //store not assigned yet so there is no collection available
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }          
        }

        private bool LessThanThreeDaysToCalibrationDate(DateTime calibrationDueDate, DateTime now)
        {
            if (calibrationDueDate <= now.AddDays(3))
            {
                return true;
            }

            return false;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SurveyStore.Modules.Calibrations.Application.Events;
using SurveyStore.Modules.Calibrations.Domain.Types;
using SurveyStore.Modules.Calibrations.Infrastructure.EF;
using SurveyStore.Shared.Abstractions.Messaging;
using SurveyStore.Shared.Abstractions.Time;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Calibrations.Infrastructure.Services
{
    public class CalibrationsDueBackgroundService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IClock _clock;

        public CalibrationsDueBackgroundService(IServiceProvider serviceProvider,
            IClock clock)
        {
            _serviceProvider = serviceProvider;
            _clock = clock;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //var queryHandler = scope.ServiceProvider
                //    .GetRequiredService<IQueryHandler<BrowseCurrentDueCalibrations, IReadOnlyCollection<CalibrationDto>>>();

                var dbContext = (CalibrationsDbContext)scope.ServiceProvider.GetRequiredService(typeof(CalibrationsDbContext));

                //var calibrations = await queryHandler.HandleAsync(new BrowseCurrentDueCalibrations());
                var calibrations = await dbContext.Calibrations
                    .Where(c => c.CalibrationDueDate.Value.Date <= _clock.Current().AddDays(7)
                        && c.CalibrationStatus == CalibrationStatus.Calibrated)
                    .ToListAsync();

                if (calibrations.Any() && calibrations is not null)
                {
                    var messageBroker = scope.ServiceProvider.GetRequiredService<IMessageBroker>();
                    foreach (var calibration in calibrations)
                    {
                        calibration.ChangeCalibrationStatus(CalibrationStatus.ToBeReturnForCalibration);
                        dbContext.Calibrations.Update(calibration);
                        await dbContext.SaveChangesAsync();

                        await messageBroker.PublishAsync(new CalibrationUpdated(calibration.SurveyEquipmentId));
                    }
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

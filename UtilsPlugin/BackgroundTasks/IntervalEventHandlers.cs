using System;
using System.Threading;
using System.Threading.Tasks;

using UtilsPlugin.Events;

using YAB.Plugins;
using YAB.Plugins.Injectables;

namespace UtilsPlugin.BackgroundTasks
{
    public class IntervalEventHandlers : IBackgroundTask
    {
        private readonly IEventSender _eventSender;

        public IntervalEventHandlers(IEventSender eventSender)
        {
            _eventSender = eventSender;
        }

        public Task InitializeAsync(CancellationToken cancellation)
        {
            return Task.CompletedTask;
        }

        public async Task RunUntilCancelledAsync(CancellationToken cancellationToken)
        {
            var secondsCounter = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1_000).ConfigureAwait(false);
                secondsCounter++;

                if (secondsCounter % 60 == 0) // every minute
                {
                    await _eventSender
                        .SendEvent(new OneMinuteIntervalEvent
                        {
                            MinuteOfHour = DateTime.UtcNow.Minute
                        }, cancellationToken)
                        .ConfigureAwait(false);
                }

                if (secondsCounter % (60 * 60) == 0) // every hour
                {
                    await _eventSender
                        .SendEvent(new OneHourIntervalEvent
                        {
                            HourOfDay = DateTime.UtcNow.Hour
                        }, cancellationToken)
                        .ConfigureAwait(false);
                }
            }
        }
    }
}
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using YAB.Core.EventReactor;
using YAB.Core.Events;

namespace UtilsPlugin.Reactors
{
    public class DebugLogPredefinedMessageReactor : IEventReactor<DebugLogPredefinedMessageReactorConfiguration, EventBase>
    {
        private readonly ILogger _logger;

        public DebugLogPredefinedMessageReactor(ILogger logger)
        {
            _logger = logger;
        }

        public Task RunAsync(DebugLogPredefinedMessageReactorConfiguration config, EventBase evt, CancellationToken cancellationToken)
        {
            _logger.LogInformation(config.DebugMessage);
            return Task.CompletedTask;
        }
    }
}
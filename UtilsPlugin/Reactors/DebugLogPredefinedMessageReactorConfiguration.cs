using YAB.Core.EventReactor;
using YAB.Core.Events;

namespace UtilsPlugin.Reactors
{
    public class DebugLogPredefinedMessageReactorConfiguration : IEventReactorConfiguration<DebugLogPredefinedMessageReactor, EventBase>
    {
        /// <summary>
        /// This determines what the bot should output into its logs when this reactor is executed.
        /// </summary>
        public string DebugMessage { get; set; }
    }
}
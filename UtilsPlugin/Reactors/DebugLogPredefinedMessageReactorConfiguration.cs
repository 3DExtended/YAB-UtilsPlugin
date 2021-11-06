﻿using YAB.Core.EventReactor;
using YAB.Core.Events;
using YAB.Plugins.Injectables.Options;

namespace UtilsPlugin.Reactors
{
    [ReactorConfigurationDescription("Will send a debug message.")]
    public class DebugLogPredefinedMessageReactorConfiguration : IEventReactorConfiguration<DebugLogPredefinedMessageReactor, EventBase>
    {
        /// <summary>
        /// This determines what the bot should output into its logs when this reactor is executed.
        /// </summary>
        [PropertyDescription(false, "The message you want to log.")]
        public string DebugMessage { get; set; }
    }
}
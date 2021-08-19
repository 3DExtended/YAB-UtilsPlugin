using YAB.Core.Events;

namespace UtilsPlugin.Events
{
    public class OneMinuteIntervalEvent : EventBase
    {
        /// <summary>
        /// Counts up from 0 to 59 and repeats.
        /// </summary>
        public int MinuteOfHour { get; set; }
    }
}
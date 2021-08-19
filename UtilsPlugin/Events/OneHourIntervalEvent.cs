using YAB.Core.Events;

namespace UtilsPlugin.Events
{
    public class OneHourIntervalEvent : EventBase
    {
        /// <summary>
        /// Counts up from 0 to 23 and repeats.
        /// </summary>
        public int HourOfDay { get; set; }
    }
}
using YAB.Core.Annotations;
using YAB.Core.Events;

namespace UtilsPlugin.Events
{
    [ClassDescription("This event is fired every full hour.")]
    public class OneHourIntervalEvent : EventBase
    {
        [PropertyDescription(false, "Counts up from 0 to 23 and repeats.")]
        public int HourOfDay { get; set; }
    }
}
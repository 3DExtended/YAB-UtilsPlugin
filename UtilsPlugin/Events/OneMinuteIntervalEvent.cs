using YAB.Core.Annotations;
using YAB.Core.Events;

namespace UtilsPlugin.Events
{
    [ClassDescription("This event is fired every full minute.")]
    public class OneMinuteIntervalEvent : EventBase
    {
        [PropertyDescription(false, "Counts up from 0 to 59 and repeats.")]
        public int MinuteOfHour { get; set; }
    }
}
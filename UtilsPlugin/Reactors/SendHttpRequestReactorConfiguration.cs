using YAB.Core.EventReactor;
using YAB.Core.Events;
using YAB.Plugins.Injectables.Options;

namespace UtilsPlugin.Reactors
{
    [ReactorConfigurationDescription("Will send a request to the URL specified. You can also provide additional headers using a json format.")]
    public class SendHttpRequestReactorConfiguration : IEventReactorConfiguration<SendHttpRequestReactor, EventBase>
    {
        [PropertyDescription(false, "Either Post, Get or Put")]
        public string RequestMethod { get; set; }

        [PropertyDescription(false, "The headers for the request. Can be left empty. Must be a dictionary of string to string serialized in json.")]
        public string SerializedHeaders { get; set; }

        [PropertyDescription(false, "The URL where the request should go to (including \"https://\" or \"http://\")")]
        public string Url { get; set; }
    }
}
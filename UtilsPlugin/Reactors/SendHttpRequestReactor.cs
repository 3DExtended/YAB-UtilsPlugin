using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using RestSharp;

using YAB.Core.EventReactor;
using YAB.Core.Events;

namespace UtilsPlugin.Reactors
{
    public class SendHttpRequestReactor : IEventReactor<SendHttpRequestReactorConfiguration, EventBase>
    {
        private readonly ILogger _logger;

        public SendHttpRequestReactor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task RunAsync(SendHttpRequestReactorConfiguration config, EventBase evt, CancellationToken cancellationToken)
        {
            var client = new RestClient(config.Url);
            client.Timeout = -1;

            RestRequest request = null;

            switch (config.RequestMethod.ToLower())
            {
                case "get":
                    request = new RestRequest(Method.GET);
                    break;

                case "post":
                    request = new RestRequest(Method.POST);
                    break;

                case "put":
                    request = new RestRequest(Method.PUT);
                    break;

                default:
                    _logger.LogInformation($"You specified {config.RequestMethod} as request method but only Get, Post and Put are allowed.");
                    return;
            }

            if (!string.IsNullOrEmpty(config.SerializedHeaders))
            {
                var headers = JsonConvert.DeserializeObject<Dictionary<string, string>>(config.SerializedHeaders);
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }
            IRestResponse response = await client.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);

            _logger.LogInformation($"Send request and got status code {response.StatusCode}");
        }
    }
}
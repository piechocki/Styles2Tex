using System;
using RestSharp;
using System.Net;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Styles2Tex.Utility
{
    class SimpleGraphQLClient
    {
        private readonly RestClient _client;

        public SimpleGraphQLClient(string GraphQLApiUrl)
        {
            _client = new RestClient(GraphQLApiUrl);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        public Task<JObject> ExecuteAsync(string query, object variables = null, Dictionary<string, string> additionalHeaders = null, int timeout = 0)
        {
            RestRequest rr = new RestRequest("/", Method.POST);
            rr.Timeout = timeout;

            if (additionalHeaders != null && additionalHeaders.Count > 0)
            {
                foreach (KeyValuePair<string, string> additionalHeader in additionalHeaders)
                {
                    rr.AddHeader(additionalHeader.Key, additionalHeader.Value);
                }
            }

            rr.AddJsonBody(new
            {
                query = query,
                variables = variables
            });

            TaskCompletionSource<JObject> tcs = new TaskCompletionSource<JObject>();
            tcs.SetResult(JObject.Parse(_client.Execute(rr).Content));
            return tcs.Task;
        }
    }
}

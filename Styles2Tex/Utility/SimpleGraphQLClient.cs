﻿using System;
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

        public async Task<JObject> ExecuteAsync(string query, object variables = null, Dictionary<string, string> additionalHeaders = null, int timeout = 0)
        {
            var rr = new RestRequest("/", Method.POST);
            rr.Timeout = timeout;

            if (additionalHeaders != null && additionalHeaders.Count > 0)
            {
                foreach (var additionalHeader in additionalHeaders)
                {
                    rr.AddHeader(additionalHeader.Key, additionalHeader.Value);
                }
            }

            rr.AddJsonBody(new
            {
                query = query,
                variables = variables
            });

            return JObject.Parse(_client.Execute(rr).Content);
        }
    }
}

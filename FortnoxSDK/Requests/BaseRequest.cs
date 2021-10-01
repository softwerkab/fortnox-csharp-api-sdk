using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Fortnox.SDK.Requests
{
    internal class BaseRequest
    {
        public HttpMethod Method { get; set; }
        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public byte[] Content { get; set; }

        public string BaseUrl { get; set; } = APIConstants.FortnoxApi;
        public string Version { get; set; } = "3";
        public string Resource { get; set; }
        public IList<string> Indices { get; set; } = new List<string>();
        public IDictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

        public string AbsoluteUrl => BuildUrl();

        private string BuildUrl()
        {
            var index = string.Join("/", Indices.Select(Uri.EscapeDataString));

            string[] str = {
                BaseUrl,
                Version,
                Resource,
                index
            };

            str = str.Where(s => s != "").ToArray();

            var requestUriString = string.Join("/", str);

            var allParams = new Dictionary<string, string>();
            if (Parameters != null)
                foreach (var keyValuePair in Parameters)
                    allParams.Add(keyValuePair.Key, keyValuePair.Value);

            if (allParams.Count > 0)
            {
                requestUriString += "/?" + string.Join("&", allParams.Select(p => p.Key + "=" + Uri.EscapeDataString(p.Value)));
            }

            return requestUriString;
        }
    }
}

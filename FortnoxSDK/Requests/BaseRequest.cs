using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Fortnox.SDK.Requests
{
    public class BaseRequest
    {
        public HttpMethod Method { get; set; }
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public byte[] Content { get; set; }

        public string BaseUrl { get; set; }
        public string Resource { get; set; }
        public List<string> Indices { get; set; } = new List<string>();
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

        public string AbsoluteUrl => BuildUrl();

        private string BuildUrl()
        {
            var index = string.Join("/", Indices.Select(HttpUtility.UrlEncode));

            string[] str = {
                BaseUrl,
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
                requestUriString += "/?" + string.Join("&", allParams.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value)));
            }

            return requestUriString;
        }
    }
}

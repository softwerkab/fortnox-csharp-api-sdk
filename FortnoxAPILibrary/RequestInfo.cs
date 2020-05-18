using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FortnoxAPILibrary
{
    public class RequestInfo
    {
        public RequestMethod Method { get; set; }
        
        public string BaseUrl { get; set; }
        public string Resource { get; set; }
        public string[] Indices { get; set; } = Array.Empty<string>();
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> SearchParameters { get; set; } = new Dictionary<string, string>();

        public RequestResponseType ResponseType { get; set; }

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
            foreach (var keyValuePair in Parameters)
                allParams.Add(keyValuePair.Key, keyValuePair.Value);
            foreach (var keyValuePair in SearchParameters)
                    allParams.Add(keyValuePair.Key, keyValuePair.Value);

            if (allParams.Count > 0)
            {
                requestUriString += "/?" + string.Join("&", allParams.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value)));
            }

            return requestUriString;
        }
    }

    public enum RequestResponseType
    {
        JSON,
        PDF,
        File
    }

    public enum RequestMethod
    {
        [EnumMember(Value = "GET")]
        Get,
        [EnumMember(Value = "POST")]
        Post,
        [EnumMember(Value = "PUT")]
        Put,
        [EnumMember(Value = "DELETE")]
        Delete
    }
}

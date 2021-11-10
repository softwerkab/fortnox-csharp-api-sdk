using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Fortnox.SDK.Requests;

internal class BaseRequest
{
    public HttpMethod Method { get; set; }
    public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
    public byte[] Content { get; set; }

    public string BaseUrl { get; set; } = ApiConstants.FortnoxApi;
    public string Version { get; set; } = "3";
    public string Resource { get; set; }
    public IList<string> Indices { get; set; } = new List<string>();
    public IDictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

    public string AbsoluteUrl => BuildUrl();

    private string BuildUrl()
    {
        var index = string.Join("/", Indices.Select(Uri.EscapeDataString));

        var pathSegments = new[]
        {
            BaseUrl,
            Version,
            Resource,
            index
        };

        var uri = string.Join("/", pathSegments.Where(s => s != ""));

        if (Parameters != null && Parameters.Any())
        {
            var query = string.Join("&", Parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
            uri += $"/?{query}";
        }

        return uri;
    }
}
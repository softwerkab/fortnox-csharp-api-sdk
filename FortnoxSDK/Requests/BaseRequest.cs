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
    public string Endpoint { get; set; }
    public IList<string> Indices { get; set; } = new List<string>();
    public IDictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

    public string AbsoluteUrl => BuildUrl();

    private string BuildUrl()
    {
        var index = string.Join("/", Indices.Where(i => i != null).Select(Uri.EscapeDataString));

        var uri = CombineUri(BaseUrl, Endpoint, index);
        var query = BuildQuery(Parameters);

        return string.IsNullOrEmpty(query) ? uri : $"{uri}?{query}";
    }

    private static string CombineUri(params string[] segments)
    {
        segments = segments
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.TrimStart('/').TrimStart('\\'))
            .Select(s => s.TrimEnd('/').TrimEnd('\\')).ToArray();

        return string.Join("/", segments);
    }

    private static string BuildQuery(IDictionary<string, string> parameters)
    {
        if (parameters == null || !parameters.Any())
            return string.Empty;

        return string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
    }
}
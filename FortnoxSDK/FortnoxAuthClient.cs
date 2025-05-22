using System.Net.Http;
using Fortnox.SDK.Auth;

namespace Fortnox.SDK;

/// <summary>
/// Entry point for Fortnox Authorization/Authentication workflow.
/// </summary>
public class FortnoxAuthClient
{
    /// <summary>
    /// Default HttpClient instance.
    /// </summary>
    internal static readonly HttpClient HttpClientSharedInstance = new HttpClient();

    /// <summary>
    /// Http client used under-the-hood for all request.
    /// </summary>
    public HttpClient HttpClient { get; set; } = HttpClientSharedInstance;

    /// <summary>
    /// HTTP/2 will be used for each request sent using the auth workflows.
    /// If set to false, HTTP/1.1 will be used.
    /// </summary>
    /// <value>Defaults to <c>true</c>.</value>
    private readonly bool UseHttp2 = true;

    public FortnoxAuthClient()
    {
    }

    public FortnoxAuthClient(bool useHttp2 = true)
    {
        UseHttp2 = useHttp2;
    }

    public FortnoxAuthClient(HttpClient httpClient, bool useHttp2 = true)
    {
        HttpClient = httpClient;
        UseHttp2 = useHttp2;
    }


    /// <summary>
    /// Used for the Fortnox legacy auth workflow.
    /// </summary>
    public IStaticTokenAuthWorkflow StaticTokenAuthWorkflow => new StaticTokenAuthWorkflow(HttpClient, useHttp2: UseHttp2);

    /// <summary>
    /// Used for the OAuth 2.0 workflow.
    /// </summary>
    public IStandardAuthWorkflow StandardAuthWorkflow => new StandardAuthWorkflow(HttpClient, useHttp2: UseHttp2);
}

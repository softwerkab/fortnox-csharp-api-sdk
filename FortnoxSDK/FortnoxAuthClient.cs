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

    public FortnoxAuthClient()
    {
    }

    public FortnoxAuthClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    /// <summary>
    /// Used for the Fortnox legacy auth workflow.
    /// </summary>
    public IStaticTokenAuthWorkflow StaticTokenAuthWorkflow => new StaticTokenAuthWorkflow(HttpClient);
    
    /// <summary>
    /// Used for the OAuth 2.0 workflow.
    /// </summary>
    public IStandardAuthWorkflow StandardAuthWorkflow => new StandardAuthWorkflow(HttpClient);
}

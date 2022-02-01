using System;
using System.Threading.Tasks;
using Fortnox.SDK.Exceptions;

namespace Fortnox.SDK.Auth;

/// <summary>
/// Represents methods of a Fortnox legacy auth workflow.
/// </summary>
[Obsolete("2022-01-09: End-of-life for the static authorization. Use StandardAuth.")]
public interface IStaticTokenAuthWorkflow
{
    /// <summary>
    /// Use this function to activate new integration and retrieve Access-Token.
    /// </summary>
    /// <param name="authCode">The API-code (authorization code) given to you by Fortnox.</param>
    /// <param name="clientSecret">The Client-Secret code given to you by Fortnox.</param>
    /// <returns>The Access-Token to use with Fortnox.</returns>
    /// <remarks>Note that an authorization-code can be used only once. Save the retrieved Access-Token in order to use it for FortnoxClient.</remarks>
    Task<string> GetTokenAsync(string authCode, string clientSecret);

    /// <summary>
    /// Use this function revoke an Access-Token and inactive the integration.
    /// </summary>
    /// <param name="accessToken">GUID-formatted token to be revoked. </param>
    /// <returns>"Revoked" property taken from the API response.</returns>
    /// <exception cref="FortnoxApiException">If the Fortnox API returns an error.</exception>
    Task<bool> RevokeTokenAsync(string accessToken);
}

using System;
using Fortnox.SDK.Authorization;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Extensions;

public static class FortnoxExtensions
{
    /// <summary>
    /// Check if the authorization has expired or is about to expire
    /// </summary>
    /// <param name="authorization">Authorization with token</param>
    /// <param name="reserve">Minimum time reserve required for the authorization to be still considered valid.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"> thrown in case of custom (unknown) auhtorization type</exception>
    public static bool IsExpired(this FortnoxAuthorization authorization, TimeSpan reserve = default)
    {
        switch (authorization)
        {
            case StaticTokenAuth:
                return false;
            case StandardAuth:
            {
                var expTimeUtc = Utils.DecodeJwt(authorization.AccessToken).ValidTo;
                return expTimeUtc - reserve < TimeZoneInfo.ConvertTimeToUtc(FortnoxServerInfo.ServerTime);
            }
            default:
                throw new NotImplementedException("Unknown authorization type");
        }
    }
}

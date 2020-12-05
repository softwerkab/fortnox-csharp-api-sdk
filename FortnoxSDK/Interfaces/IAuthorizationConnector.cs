using System.Threading.Tasks;

namespace Fortnox.SDK.Interfaces
{
    public interface IAuthorizationConnector : IConnector
    {
        string GetAccessToken(string authorizationCode, string clientSecret);
        Task<string> GetAccessTokenAsync(string authorizationCode, string clientSecret);
    }
}

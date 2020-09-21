using System.Threading.Tasks;

namespace FortnoxAPILibrary.Connectors
{
    public interface IAuthorizationConnector : IBaseConnector
    {
        string GetAccessToken(string authorizationCode, string clientSecret);
        Task<string> GetAccessTokenAsync(string authorizationCode, string clientSecret);
    }
}

namespace FortnoxAPILibrary.Connectors
{
    public interface IAuthorizationConnector : IConnector
    {
        string GetAccessToken(string authorizationCode, string clientSecret);
    }
}

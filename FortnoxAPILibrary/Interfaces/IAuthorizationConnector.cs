namespace FortnoxAPILibrary.Connectors
{
    public interface IAuthorizationConnector
    {
        string GetAccessToken(string authorizationCode, string clientSecret);
    }
}

using System;

namespace FortnoxAPILibrary.Tests.Connectors
{
    public abstract class ConnectorTestsBase
    {
        //Enter these values to run tests. DO NOT CHECK THESE CREDENTIALS IN. Also make sure this is not production account, these tests will make changes to the data.
        protected static string AccessToken = "";
        protected static string ClientSecret = "";

        protected ConnectorTestsBase()
        {
            AccessToken = string.IsNullOrEmpty(AccessToken) ? Environment.GetEnvironmentVariable("Fortnox_AccessToken") : AccessToken;
            ClientSecret = string.IsNullOrEmpty(ClientSecret) ? Environment.GetEnvironmentVariable("Fortnox_ClientSecret") : ClientSecret;

            if (string.IsNullOrEmpty(AccessToken) || string.IsNullOrEmpty(ClientSecret))
                throw new ArgumentException("You have to add access token and client secret to be able to run these tests");
        }

        protected static void CheckForError<TE>(IEntityConnector<TE> connector)
        {
            if (connector.HasError)
                throw new Exception($"{connector.Error.Message} ({connector.Error.Code})");
        }
    }
}
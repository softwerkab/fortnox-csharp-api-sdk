using System.Collections.Generic;
using Fortnox.SDK;
using Fortnox.SDK.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests
{
    [TestClass]
    public class AuthTests
    {
        [Ignore("Requires new authorization code.")]
        [TestMethod]
        public void Test_StaticTokenAuth_GetToken()
        {
            var clientSecret = TestCredentials.Client_Secret;
            var authorizationCode = "ca7f0830-ccf1-63f8-f750-1f78f50c0d58";

            var fortnoxAuthClient = new FortnoxAuthClient();
            var authWorkflow = fortnoxAuthClient.StaticTokenAuthWorkflow;

            var token = authWorkflow.GetToken(authorizationCode, clientSecret);
            Assert.IsNotNull(token);
        }

        [Ignore("Requires valid authorization code")]
        [TestMethod]
        public void Test_StandardAuth_GetToken()
        {
            var clientId = "8VurtMGDTeAI"; //"bhgmY4FYebfj";
            var clientSecret = "yFKwme8LEQ"; //"TestCredentials.Client_Secret;
            var redirectUri = "https://mysite.org/activation";
            var authorizationCode = "Placeholder";
            
            var fortnoxAuthClient = new FortnoxAuthClient();
            var authWorkflow = fortnoxAuthClient.StandardAuthWorkflow;

            var token = authWorkflow.GetToken(authorizationCode, clientId, clientSecret, redirectUri);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void Test_BuildUri_Example()
        {
            var clientId = "8VurtMGDTeAI";
            var clientSecret = "yFKwme8LEQ";
            var redirectUri = "https://mysite.org/activation";
            var scopes = new List<Scope>()
            {
                Scope.CompanyInformation
            };
            var state = "somestate123";

            var fortnoxAuthClient = new FortnoxAuthClient();
            var authWorkflow = fortnoxAuthClient.StandardAuthWorkflow;

            var uri = authWorkflow.BuildAuthUri(clientId, scopes, state, redirectUri);
            Assert.AreEqual(@"https://apps.fortnox.se/oauth-v1/auth?client_id=8VurtMGDTeAI&redirect_uri=https%3A%2F%2Fmysite.org%2Factivation&scope=companyinformation&state=somestate123&access_type=offline&response_type=code", uri.AbsoluteUri);
        }

        [TestMethod]
        public void Test_BuildUri_MultipleScopes()
        {
            var clientId = "8VurtMGDTeAI";
            var clientSecret = "yFKwme8LEQ";
            var redirectUri = "https://mysite.org/activation";
            var scopes = new List<Scope>()
            {
                Scope.Article,
                Scope.Bookkeeping,
                Scope.Customer
            };
            var state = "somestate123";

            var fortnoxAuthClient = new FortnoxAuthClient();
            var authWorkflow = fortnoxAuthClient.StandardAuthWorkflow;

            var uri = authWorkflow.BuildAuthUri(clientId, scopes, state, redirectUri);
            Assert.AreEqual(@"https://apps.fortnox.se/oauth-v1/auth?client_id=8VurtMGDTeAI&redirect_uri=https%3A%2F%2Fmysite.org%2Factivation&scope=article%20bookkeeping%20customer&state=somestate123&access_type=offline&response_type=code", uri.AbsoluteUri);
        }
    }
}

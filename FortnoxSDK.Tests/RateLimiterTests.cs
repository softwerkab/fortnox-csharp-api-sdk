using System;
using System.Diagnostics;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests
{
    [TestClass]
    public class RateLimiterTests
    {
        [TestInitialize]
        public void Init()
        {
            //Set global credentials for SDK
            //--- Open 'TestCredentials.resx' to edit the values ---\\
            ConnectionCredentials.AccessToken = TestCredentials.Access_Token;
            ConnectionCredentials.ClientSecret = TestCredentials.Client_Secret;
        }

        [TestMethod]
        public void Test_RateLimiter_NoError()
        {
            var connector = new CustomerConnector();

            var watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < 200; i++)
            {
                var searchSettings = new CustomerSearch();
                searchSettings.City = TestUtils.RandomString(); //Needs to be random to make unique GET request
                connector.Find(searchSettings);
            }

            watch.Stop();
            Console.WriteLine(@"Total time: " + watch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void Test_NoRateLimiter_TooManyRequest_Error()
        {
            ConnectionSettings.UseRateLimiter = false;
            var connector = new CustomerConnector();

            FortnoxApiException error = null;
            int i;
            for (i = 0; i < 200; i++)
            {
                var searchSettings = new CustomerSearch();
                searchSettings.City = TestUtils.RandomString();
                try
                {
                    connector.Find(searchSettings);
                }
                catch (FortnoxApiException ex)
                {
                    error = ex;
                    break;
                }
            }

            //Restore searchSettings
            ConnectionSettings.UseRateLimiter = true;

            //Assert
            //Assert.IsTrue(failed > 0);
            Console.WriteLine($@"Succesful requests: {i}");
            Assert.IsNotNull(error);
            Console.WriteLine(error.Message);
            Assert.IsTrue(error.Message.Contains("Too Many Requests"));
        }
    }
}

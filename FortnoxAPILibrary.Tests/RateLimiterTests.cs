using System;
using System.Diagnostics;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
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
                connector.Search.City = TestUtils.RandomString(); //Needs to be random to make unique GET request
                connector.Find();
                MyAssert.HasNoError(connector);
            }

            watch.Stop();
            Console.WriteLine(@"Total time: " + watch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void Test_NoRateLimiter_TooManyRequest_Error()
        {
            ConnectionSettings.UseRateLimiter = false;
            var connector = new CustomerConnector();

            ErrorInformation error = null;
            int i;
            for (i = 0; i < 200; i++)
            {
                connector.Search.City = TestUtils.RandomString();
                connector.Find();
                if (connector.HasError)
                {
                    error = connector.Error;
                    break;
                }
            }

            //Restore settings
            ConnectionSettings.UseRateLimiter = true;

            //Assert
            //Assert.IsTrue(failed > 0);
            Console.WriteLine($@"Succesful requests: {i}");
            Assert.IsNotNull(error);
            Assert.IsTrue(error.Message.Contains("Too Many Requests"));
        }
    }
}

using System;
using System.Diagnostics;
using System.Threading;
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
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_RateLimiter_NoError()
        {
            var connector = FortnoxClient.CustomerConnector;

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
            var connector = FortnoxClient.CustomerConnector;
            connector.UseRateLimiter = false;

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

            //Assert
            //Assert.IsTrue(failed > 0);
            Console.WriteLine($@"Succesful requests: {i}");
            Assert.IsNotNull(error);
            Console.WriteLine(error.Message);
            Assert.IsTrue(error.Message.Contains("Too Many Requests"));

            Thread.Sleep(5*1000); //Sleep to cooldown/recover from "debt" (otherwise following tests will fail with TooManyRequests)
        }
    }
}

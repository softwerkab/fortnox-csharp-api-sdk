using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Authorization;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests;

[TestClass]
public class RateLimiterTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_RateLimiter_NoError()
    {
        var connector = FortnoxClient.CustomerConnector;

        var watch = new Stopwatch();
        watch.Start();

        var counter = 0;
        for (var i = 0; i < 200; i++)
        {
            var searchSettings = new CustomerSearch();
            searchSettings.City = TestUtils.RandomString(); //Needs to be random to make unique GET request
            await connector.FindAsync(searchSettings);
            counter++;
        }

        watch.Stop();

        /*
         * Given the rate limiter of 4 requests per second,
         * 200 requests should be executed in ~50 seconds.
         */
        Assert.AreEqual(200, counter);
        Assert.IsTrue(watch.Elapsed.TotalSeconds is > 49 and < 51);
    }

    [Ignore("Can make other test fail due to exhausting rate limiter")]
    [TestMethod]
    public async Task Test_NoRateLimiter_TooManyRequest_Error()
    {
        var fortnoxClient = new FortnoxClient()
        {
            Authorization = new StaticTokenAuth(TestCredentials.Access_Token, TestCredentials.Client_Secret),
            UseRateLimiter = false
        };

        var connector = fortnoxClient.CustomerConnector;

        FortnoxApiException error = null;
        int i;
        for (i = 0; i < 200; i++)
        {
            var searchSettings = new CustomerSearch();
            searchSettings.City = TestUtils.RandomString();
            try
            {
                await connector.FindAsync(searchSettings);
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

        Thread.Sleep(5 * 1000); //Sleep to cooldown/recover from "debt" (otherwise following tests will fail with TooManyRequests)
    }
}
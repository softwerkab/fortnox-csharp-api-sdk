using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Authorization;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests;

[TestClass]
public class RateLimiterTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }

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
         * Given the rate limiter of 4.8 requests per second (24/5),
         * 200 requests should be executed in ~41 seconds.
         * 
         * If we can increase the rate limiter to the advertised 25/5 (5 per second), 
         * 200 requests should be executed in ~40 seconds.
         */

        Assert.AreEqual(200, counter);
        Assert.IsTrue(watch.Elapsed.TotalSeconds is > 40);
    }

    [Ignore("Can make other test fail due to exhausting rate limiter")]
    [TestMethod]
    public async Task Test_NoRateLimiter_TooManyRequest_Error()
    {
        var fortnoxClient = new FortnoxClient()
        {
            Authorization = new StaticTokenAuth(TestCredentials.Access_Token_OLD, TestCredentials.Client_Secret_OLD),
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

    class CustomRateLimiter : IRateLimiter
    {
        public async Task<HttpResponseMessage> Throttle(string token, Func<Task<HttpResponseMessage>> action)
        {
            Console.WriteLine("Waiting 1 second...");
            await Task.Delay(1000).ConfigureAwait(false);
            Console.WriteLine("Execute request");
            var res = await action().ConfigureAwait(false);
            Console.WriteLine("Done execute request");
            return res;
        }
    }

    [TestMethod]
    public async Task Test_CustomRateLimiter()
    {
        var fortnoxAuthClient = new FortnoxAuthClient();
        var authWorkflow = fortnoxAuthClient.StandardAuthWorkflow;
        var token = await authWorkflow.GetTokenByClientCredentialsAsync(TestCredentials.ClientId, TestCredentials.ClientSecret, int.Parse(TestCredentials.TenantId));
        var authorization = new StandardAuth(token.AccessToken);
        var fortnoxClient = new FortnoxClient
        {
            Authorization = authorization,
            UseRateLimiter = true,
            RateLimiter = new CustomRateLimiter()
        };

        var connector = fortnoxClient.CustomerConnector;

        var watch = new Stopwatch();
        watch.Start();

        FortnoxApiException error = null;
        int i;
        for (i = 0; i < 5; i++)
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

        watch.Stop();

        Assert.IsNull(error);
        Assert.IsTrue(watch.Elapsed.TotalSeconds > 4);
    }
}
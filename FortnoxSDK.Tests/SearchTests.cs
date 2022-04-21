using System;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests;

[TestClass]
public class SearchTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_CustomParameters()
    {
        var connector = FortnoxClient.FinancialYearConnector;

        var query = new FinancialYearSearch();
        query.CustomParameters.Add("date", "2022-05-24");

        var results = await connector.FindAsync(query);

        Assert.AreEqual(1, results.Entities.Count);
        Assert.AreEqual(new DateTime(2022, 1, 1), results.Entities.Single().FromDate);
        Assert.AreEqual(new DateTime(2022, 12, 31), results.Entities.Single().ToDate);
    }
}

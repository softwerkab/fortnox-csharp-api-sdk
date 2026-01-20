using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class PrintTemplateTests
{
    private FortnoxClient FortnoxClient;

    [TestInitialize]
    public async Task TestInitialize()
    {
        FortnoxClient ??= await TestClient.GetFortnoxClient();
    }

    [TestMethod]
    public void Test_PrintTemplate_CRUD()
    {
        //Not supported
    }

    [TestMethod]
    public async Task Test_PrintTemplate_Find()
    {
        var connector = FortnoxClient.PrintTemplateConnector;

        var fullCollection = await connector.FindAsync(null);

        Assert.AreEqual(8, fullCollection.Entities.Count);
        Assert.IsNotNull(fullCollection.Entities.First().Name);

        //Limit not supported
    }

    [TestMethod]
    public async Task Test_PrintTemplate_Find_Filter()
    {
        var connector = FortnoxClient.PrintTemplateConnector;
        var searchSettings = new PrintTemplateSearch();

        searchSettings.FilterBy = Filter.PrintTemplate.Order;
        var orderTemplates = await connector.FindAsync(searchSettings);

        Assert.AreEqual(3, orderTemplates.Entities.Count);

        searchSettings.FilterBy = Filter.PrintTemplate.Offer;
        var offerTemplates = await connector.FindAsync(searchSettings);

        Assert.AreEqual(1, offerTemplates.Entities.Count);

        searchSettings.FilterBy = Filter.PrintTemplate.Invoice;
        var invoiceTemplates = await connector.FindAsync(searchSettings);

        Assert.AreEqual(8, invoiceTemplates.Entities.Count);
    }
}
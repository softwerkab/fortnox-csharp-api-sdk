using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class PrintTemplateTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_PrintTemplate_CRUD()
        {
            //Not supported
        }

        [TestMethod]
        public void Test_Find()
        {
            IPrintTemplateConnector connector = new PrintTemplateConnector();
            
            var fullCollection = connector.Find(null);

            Assert.AreEqual(9, fullCollection.Entities.Count);
            Assert.IsNotNull(fullCollection.Entities.First().Name);

            //Limit not supported
        }

        [TestMethod]
        public void Test_Find_Filter()
        {
            IPrintTemplateConnector connector = new PrintTemplateConnector();
            var searchSettings = new PrintTemplateSearch();

            searchSettings.FilterBy = Filter.PrintTemplate.Order;
            var orderTemplates = connector.Find(searchSettings);

            Assert.AreEqual(3, orderTemplates.Entities.Count);

            searchSettings.FilterBy = Filter.PrintTemplate.Offer;
            var offerTemplates = connector.Find(searchSettings);

            Assert.AreEqual(1, offerTemplates.Entities.Count);

            searchSettings.FilterBy = Filter.PrintTemplate.Invoice;
            var invoiceTemplates = connector.Find(searchSettings);

            Assert.AreEqual(9, invoiceTemplates.Entities.Count);
        }
    }
}

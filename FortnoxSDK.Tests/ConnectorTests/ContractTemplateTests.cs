using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class ContractTemplateTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_ContractTemplate_CRUD()
    {
        #region Arrange
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle" });
        #endregion Arrange

        var connector = FortnoxClient.ContractTemplateConnector;

        #region CREATE
        var newContractTemplate = new ContractTemplate()
        {
            ContractLength = 4,
            Continuous = false,
            InvoiceInterval = 3,
            InvoiceRows = new List<ContractTemplateInvoiceRow>()
            {
                new ContractTemplateInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10}
            },
            TemplateName = "TestTemplate",
        };

        var createdContractTemplate = await connector.CreateAsync(newContractTemplate);
        Assert.AreEqual("TestTemplate", createdContractTemplate.TemplateName);

        #endregion CREATE

        #region UPDATE

        createdContractTemplate.TemplateName = "UpdatedTestTemplate";

        var updatedContractTemplate = await connector.UpdateAsync(createdContractTemplate);
        Assert.AreEqual("UpdatedTestTemplate", updatedContractTemplate.TemplateName);

        #endregion UPDATE

        #region READ / GET

        var retrievedContractTemplate = await connector.GetAsync(createdContractTemplate.TemplateNumber);
        Assert.AreEqual("UpdatedTestTemplate", retrievedContractTemplate.TemplateName);

        #endregion READ / GET

        #region DELETE
        //Not supported
        #endregion DELETE

        #region Delete arranged resources
        //FortnoxClient.ArticleConnector.Delete(tmpArticle.ArticleNumber);
        #endregion Delete arranged resources
    }

    [Ignore("LastModified parameter is not accepted")]
    [TestMethod]
    public async Task Test_ContractTemplate_Find()
    {
        #region Arrange
        var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle" });
        #endregion Arrange

        var connector = FortnoxClient.ContractTemplateConnector;

        var marks = TestUtils.RandomString();

        var newContractTemplate = new ContractTemplate()
        {
            ContractLength = 4,
            Continuous = false,
            InvoiceInterval = 3,
            InvoiceRows = new List<ContractTemplateInvoiceRow>()
            {
                new ContractTemplateInvoiceRow(){ ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10}
            },
        };

        for (var i = 0; i < 5; i++)
        {
            newContractTemplate.TemplateName = marks + i;
            await connector.CreateAsync(newContractTemplate);
        }

        var searchSettings = new ContractTemplateSearch();
        searchSettings.LastModified = TestUtils.Recently;
        var templates = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, templates.Entities.Count(c => c.TemplateName.StartsWith(marks)));

        //No delete supported
    }
}
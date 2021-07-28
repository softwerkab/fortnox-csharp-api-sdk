using System;
using System.Collections.Generic;
using System.Linq;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class ContractTemplateTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public void Test_ContractTemplate_CRUD()
        {
            #region Arrange
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article(){ Description = "TmpArticle" });
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

            var createdContractTemplate = connector.Create(newContractTemplate);
            Assert.AreEqual("TestTemplate", createdContractTemplate.TemplateName);

            #endregion CREATE

            #region UPDATE

            createdContractTemplate.TemplateName = "UpdatedTestTemplate";

            var updatedContractTemplate = connector.Update(createdContractTemplate); 
            Assert.AreEqual("UpdatedTestTemplate", updatedContractTemplate.TemplateName);

            #endregion UPDATE

            #region READ / GET

            var retrievedContractTemplate = connector.Get(createdContractTemplate.TemplateNumber);
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
        public void Test_ContractTemplate_Find()
        {
            #region Arrange
            var tmpArticle = FortnoxClient.ArticleConnector.Create(new Article() { Description = "TmpArticle" });
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
                connector.Create(newContractTemplate);
            }

            var searchSettings = new ContractTemplateSearch();
            searchSettings.LastModified = TestUtils.Recently;
            var templates = connector.Find(searchSettings);

            Assert.AreEqual(5, templates.Entities.Count(c => c.TemplateName.StartsWith(marks)));

            //No delete supported
        }
    }
}

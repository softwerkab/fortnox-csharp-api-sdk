using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class ArticleTests
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
        public void Test_Article_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new ArticleConnector();

            #region CREATE
            var newArticle = new Article()
            {
                //TODO: Populate Entity
            };

            var createdArticle = connector.Create(newArticle);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdArticle.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdArticle.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedArticle = connector.Update(createdArticle); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedArticle.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedArticle = connector.Get(createdArticle.ArticleNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedArticle.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdArticle.ArticleNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedArticle = connector.Get(createdArticle.ArticleNumber); //TODO: Check ID property
            Assert.AreEqual(null, retrievedArticle, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}

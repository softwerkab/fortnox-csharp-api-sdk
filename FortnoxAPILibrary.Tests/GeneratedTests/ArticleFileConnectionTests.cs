using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class ArticleFileConnectionTests
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
        public void Test_ArticleFileConnection_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new ArticleFileConnectionConnector();

            #region CREATE
            var newArticleFileConnection = new ArticleFileConnection()
            {
                //TODO: Populate Entity
            };

            var createdArticleFileConnection = connector.Create(newArticleFileConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdArticleFileConnection.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdArticleFileConnection.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedArticleFileConnection = connector.Update(createdArticleFileConnection); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedArticleFileConnection.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedArticleFileConnection = connector.Get(createdArticleFileConnection.FileId); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedArticleFileConnection.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdArticleFileConnection.FileId); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedArticleFileConnection = connector.Get(createdArticleFileConnection.FileId); //TODO: Check ID property
            Assert.AreEqual(null, retrievedArticleFileConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}

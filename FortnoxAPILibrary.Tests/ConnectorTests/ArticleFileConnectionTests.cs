using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
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

            var tmpArticle = new ArticleConnector().Create(new Article() {Description = "TmpArticle"});
            var tmpFile = new ArchiveConnector().UploadFile("tmpImage.png", Resource.fortnox_image);

            #endregion Arrange

            IArticleFileConnectionConnector connector = new ArticleFileConnectionConnector();

            #region CREATE

            var newArticleFileConnection = new ArticleFileConnection()
            {
                FileId = tmpFile.Id,
                ArticleNumber = tmpArticle.ArticleNumber
            };

            var createdArticleFileConnection = connector.Create(newArticleFileConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(tmpArticle.ArticleNumber, createdArticleFileConnection.ArticleNumber);

            #endregion CREATE

            #region UPDATE

            //Update not supported

            #endregion UPDATE

            #region READ / GET

            var retrievedArticleFileConnection = connector.Get(createdArticleFileConnection.FileId);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(tmpArticle.ArticleNumber, retrievedArticleFileConnection.ArticleNumber);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdArticleFileConnection.FileId);
            MyAssert.HasNoError(connector);

            retrievedArticleFileConnection = connector.Get(createdArticleFileConnection.FileId);
            Assert.AreEqual(null, retrievedArticleFileConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources

            new ArticleConnector().Delete(tmpArticle.ArticleNumber);
            new ArchiveConnector().DeleteFile(tmpFile.Id);

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_ArticleFileConnection_Find()
        {
            #region Arrange

            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle" });
            #endregion Arrange

            IArticleFileConnectionConnector connector = new ArticleFileConnectionConnector();

            var newArticleFileConnection = new ArticleFileConnection()
            {
                ArticleNumber = tmpArticle.ArticleNumber
            };

            for (var i = 0; i < 5; i++)
            {
                var tmpFile = new ArchiveConnector().UploadFile($"tmpImage{i}.png", Resource.fortnox_image);
                newArticleFileConnection.FileId = tmpFile.Id;

                connector.Create(newArticleFileConnection);
                MyAssert.HasNoError(connector);
            }

            connector.ArticleNumber = tmpArticle.ArticleNumber;
            var connections = connector.Find();
            Assert.AreEqual(5, connections.Entities.Count);

            foreach (var entity in connections.Entities)
            {
                connector.Delete(entity.FileId);
                MyAssert.HasNoError(connector);

                new ArchiveConnector().DeleteFile(entity.FileId);
            }

            #region Delete arranged resources

            new ArticleConnector().Delete(tmpArticle.ArticleNumber);

            #endregion Delete arranged resources
        }
    }
}

using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests
{
    [TestClass]
    public class ArticleFileConnectionTests
    {
        public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

        [TestMethod]
        public async Task Test_ArticleFileConnection_CRUD()
        {
            #region Arrange

            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle" });
            var tmpFile = await FortnoxClient.ArchiveConnector.UploadFileAsync("tmpImage.png", Resource.fortnox_image);

            #endregion Arrange

            var connector = FortnoxClient.ArticleFileConnectionConnector;

            #region CREATE

            var newArticleFileConnection = new ArticleFileConnection()
            {
                FileId = tmpFile.Id,
                ArticleNumber = tmpArticle.ArticleNumber
            };

            var createdArticleFileConnection = await connector.CreateAsync(newArticleFileConnection);
            Assert.AreEqual(tmpArticle.ArticleNumber, createdArticleFileConnection.ArticleNumber);

            #endregion CREATE

            #region UPDATE

            //Update not supported

            #endregion UPDATE

            #region READ / GET

            var retrievedArticleFileConnection = await connector.GetAsync(createdArticleFileConnection.FileId);
            Assert.AreEqual(tmpArticle.ArticleNumber, retrievedArticleFileConnection.ArticleNumber);

            #endregion READ / GET

            #region DELETE

            await connector.DeleteAsync(createdArticleFileConnection.FileId);

            Assert.ThrowsException<FortnoxApiException>(
                () => connector.Get(createdArticleFileConnection.FileId),
                "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources

            await FortnoxClient.ArticleConnector.DeleteAsync(tmpArticle.ArticleNumber);
            await FortnoxClient.ArchiveConnector.DeleteFileAsync(tmpFile.Id);

            #endregion Delete arranged resources
        }

        [TestMethod]
        public async Task Test_ArticleFileConnection_Find()
        {
            #region Arrange

            var tmpArticle = await FortnoxClient.ArticleConnector.CreateAsync(new Article() { Description = "TmpArticle" });
            #endregion Arrange

            var connector = FortnoxClient.ArticleFileConnectionConnector;

            var newArticleFileConnection = new ArticleFileConnection()
            {
                ArticleNumber = tmpArticle.ArticleNumber
            };

            for (var i = 0; i < 5; i++)
            {
                var tmpFile = await FortnoxClient.ArchiveConnector.UploadFileAsync($"tmpImage{i}.png", Resource.fortnox_image);
                newArticleFileConnection.FileId = tmpFile.Id;

                await connector.CreateAsync(newArticleFileConnection);
            }

            var searchSettings = new ArticleFileConnectionSearch();
            searchSettings.ArticleNumber = tmpArticle.ArticleNumber;
            var connections = await connector.FindAsync(searchSettings);
            Assert.AreEqual(5, connections.Entities.Count);

            foreach (var entity in connections.Entities)
            {
                await connector.DeleteAsync(entity.FileId);

                await FortnoxClient.ArchiveConnector.DeleteFileAsync(entity.FileId);
            }

            #region Delete arranged resources

            await FortnoxClient.ArticleConnector.DeleteAsync(tmpArticle.ArticleNumber);

            #endregion Delete arranged resources
        }
    }
}

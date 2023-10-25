using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests.ConnectorTests;

[TestClass]
public class TermsOfPaymentTests
{
    public FortnoxClient FortnoxClient = TestUtils.DefaultFortnoxClient;

    [TestMethod]
    public async Task Test_TermsOfPayment_CRUD()
    {
        #region Arrange
        //Add code to create required resources
        #endregion Arrange

        var connector = FortnoxClient.TermsOfPaymentConnector;

        #region CREATE
        var newTermsOfPayment = new TermsOfPayment()
        {
            Code = TestUtils.RandomString(5),
            Description = "TestPaymentTerms"
        };

        var createdTermsOfPayment = await connector.CreateAsync(newTermsOfPayment);
        Assert.AreEqual("TestPaymentTerms", createdTermsOfPayment.Description);

        #endregion CREATE

        #region UPDATE

        createdTermsOfPayment.Description = "UpdatedTestPaymentTerms";

        var updatedTermsOfPayment = await connector.UpdateAsync(createdTermsOfPayment);
        Assert.AreEqual("UpdatedTestPaymentTerms", updatedTermsOfPayment.Description);

        #endregion UPDATE

        #region READ / GET

        var retrievedTermsOfPayment = await connector.GetAsync(createdTermsOfPayment.Code);
        Assert.AreEqual("UpdatedTestPaymentTerms", retrievedTermsOfPayment.Description);

        #endregion READ / GET

        #region DELETE

        await connector.DeleteAsync(createdTermsOfPayment.Code);

        await Assert.ThrowsExceptionAsync<FortnoxApiException>(
            async () => await connector.GetAsync(createdTermsOfPayment.Code),
            "Entity still exists after Delete!");

        #endregion DELETE

        #region Delete arranged resources
        //Add code to delete temporary resources
        #endregion Delete arranged resources
    }

    [TestMethod]
    public async Task Test_Find()
    {
        var connector = FortnoxClient.TermsOfPaymentConnector;

        // delete existing entities becuase due to that exiting records, test not passing for 5.  Assert.AreEqual(5, fullCollection.Entities.Count); // line 100
        var searchSettingsExits = new TermsOfPaymentSearch();
        searchSettingsExits.LastModified = TestUtils.Recently;
        var fullCollectionExists = await connector.FindAsync(searchSettingsExits);

        if (fullCollectionExists.TotalPages == 1)
        {
            // Delete already exists entries
            foreach (var entry in fullCollectionExists.Entities)
            {
                await connector.DeleteAsync(entry.Code);
            }
        }
        else
        {
            var pages = fullCollectionExists.TotalPages;

            for (int i = 0; i < pages; i++)
            {
                foreach (var entry in fullCollectionExists.Entities)
                {
                    await connector.DeleteAsync(entry.Code);
                } 

                searchSettingsExits.Page = fullCollectionExists.CurrentPage + 1;
                fullCollectionExists = await connector.FindAsync(searchSettingsExits);
            }
        }
       

        var newTermsOfPayment = new TermsOfPayment()
        {
            Description = "TestPaymentTerms"
        };

        //Add entries
        for (var i = 0; i < 5; i++)
        {
            newTermsOfPayment.Code = TestUtils.RandomString();
            await connector.CreateAsync(newTermsOfPayment);
        }

        //Filter not supported
        var searchSettings = new TermsOfPaymentSearch();
        searchSettings.LastModified = TestUtils.Recently;
        var fullCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(5, fullCollection.Entities.Count);
        Assert.AreEqual("TestPaymentTerms", fullCollection.Entities[0].Description);

        //Apply Limit
        searchSettings.Limit = 2;
        var limitedCollection = await connector.FindAsync(searchSettings);

        Assert.AreEqual(2, limitedCollection.Entities.Count);

        //Delete entries
        foreach (var entry in fullCollection.Entities)
        {
            await connector.DeleteAsync(entry.Code);
        }
    }
}
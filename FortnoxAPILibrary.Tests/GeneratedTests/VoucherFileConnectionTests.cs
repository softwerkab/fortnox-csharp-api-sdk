using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class VoucherFileConnectionTests
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
        public void Test_VoucherFileConnection_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new VoucherFileConnectionConnector();

            #region CREATE
            var newVoucherFileConnection = new VoucherFileConnection()
            {
                //TODO: Populate Entity
            };

            var createdVoucherFileConnection = connector.Create(newVoucherFileConnection);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdVoucherFileConnection.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdVoucherFileConnection.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedVoucherFileConnection = connector.Update(createdVoucherFileConnection); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedVoucherFileConnection.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedVoucherFileConnection = connector.Get(createdVoucherFileConnection.FileId); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedVoucherFileConnection.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdVoucherFileConnection.FileId); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedVoucherFileConnection = connector.Get(createdVoucherFileConnection.FileId); //TODO: Check ID property
            Assert.AreEqual(null, retrievedVoucherFileConnection, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}

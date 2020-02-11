using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class SupplierTests
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
        public void Test_Supplier_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new SupplierConnector();

            #region CREATE
            var newSupplier = new Supplier()
            {
                //TODO: Populate Entity
            };

            var createdSupplier = connector.Create(newSupplier);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdSupplier.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdSupplier.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedSupplier = connector.Update(createdSupplier); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedSupplier.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplier = connector.Get(createdSupplier.SupplierNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedSupplier.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSupplier.SupplierNumber); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedSupplier = connector.Get(createdSupplier.SupplierNumber); //TODO: Check ID property
            Assert.AreEqual(null, retrievedSupplier, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}

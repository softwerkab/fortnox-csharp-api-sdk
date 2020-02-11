using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class ExpenseTests
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
        public void Test_Expense_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new ExpenseConnector();

            #region CREATE
            var newExpense = new Expense()
            {
                //TODO: Populate Entity
            };

            var createdExpense = connector.Create(newExpense);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("PropertyValue", createdExpense.SomeProperty); //TODO: Adapt

            #endregion CREATE

            #region UPDATE

            createdExpense.SomeProperty = "UpdatedPropertyValue"; //TODO: Adapt

            var updatedExpense = connector.Update(createdExpense); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", updatedExpense.SomeProperty); //TODO: Adapt

            #endregion UPDATE

            #region READ / GET

            var retrievedExpense = connector.Get(createdExpense.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedPropertyValue", retrievedExpense.SomeProperty); //TODO: Adapt

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdExpense.Code); //TODO: Check ID property
            MyAssert.HasNoError(connector);

            retrievedExpense = connector.Get(createdExpense.Code); //TODO: Check ID property
            Assert.AreEqual(null, retrievedExpense, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}

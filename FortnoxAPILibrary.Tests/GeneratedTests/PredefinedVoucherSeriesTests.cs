using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class PredefinedVoucherSeriesTests
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
        public void Test_PredefinedVoucherSeries_CRUD()
        {
            var connector = new PredefinedVoucherSeriesConnector();

            //Get
            var predefinedVoucherSeries = connector.Get("INVOICE");
            MyAssert.HasNoError(connector);
            Assert.AreEqual("B", predefinedVoucherSeries.VoucherSeries);

            //Update
            predefinedVoucherSeries.VoucherSeries = "L"; //Lon -> "SALARY"
            MyAssert.HasNoError(connector);
            Assert.AreEqual("L", predefinedVoucherSeries.VoucherSeries);

            //Reset
            predefinedVoucherSeries.VoucherSeries = "B";
            MyAssert.HasNoError(connector);
            Assert.AreEqual("B", predefinedVoucherSeries.VoucherSeries);
        }
    }
}

using System;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.SDK.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.Connectors
{
    [TestClass]
    //Update AccessToken, ClientSecret before run tests and clear those values when you finished
    public class SupplierInvoiceConnectorTests : ConnectorTestsBase
    {
        readonly ISupplierInvoiceConnector _connector;

        public SupplierInvoiceConnectorTests()
        {
            _connector = new SupplierInvoiceConnector
            {
                Authorization = new StandardAuth(AccessToken)
            };
        }

        [TestMethod]
        public void GetSupplierInvoices()
        {
            _connector.SortBy = Sort.By.SupplierInvoice.InvoiceDate;
            _connector.SortOrder = Sort.Order.Descending;
            var supplierInvoices = _connector.Find().SupplierInvoiceSubset;

            var firstInvoiceDate = DateTime.Parse(supplierInvoices.First().InvoiceDate);
            var lastInvoiceDate = DateTime.Parse(supplierInvoices.Last().InvoiceDate);
            Assert.IsTrue(firstInvoiceDate > lastInvoiceDate);

            _connector.SortOrder = Sort.Order.Ascending;
            supplierInvoices = _connector.Find().SupplierInvoiceSubset;

            firstInvoiceDate = DateTime.Parse(supplierInvoices.First().InvoiceDate);
            lastInvoiceDate = DateTime.Parse(supplierInvoices.Last().InvoiceDate);
            Assert.IsTrue(lastInvoiceDate > firstInvoiceDate);
        }
    }
}

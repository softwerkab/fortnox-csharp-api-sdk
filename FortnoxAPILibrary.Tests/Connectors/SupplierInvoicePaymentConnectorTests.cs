using System.Linq;
using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.Connectors
{
    [TestClass]
    //Update AccessToken, ClientSecret before run tests and clear those values when you finished
    public class SupplierInvoicePaymentConnectorTests : ConnectorTestsBase
    {
        readonly ISupplierInvoicePaymentConnector _connector;

        public SupplierInvoicePaymentConnectorTests()
        {
            _connector = new SupplierInvoicePaymentConnector
            {
                AccessToken = AccessToken,
                ClientSecret = ClientSecret
            };
        }

        [TestMethod]
        public void GetSupplierInvoices()
        {
            var supplierInvoicePaymentsResponse = _connector.Find();
            Assert.AreNotEqual(supplierInvoicePaymentsResponse.SupplierInvoicePaymentSubset, null);
            Assert.IsTrue(supplierInvoicePaymentsResponse.SupplierInvoicePaymentSubset.Any());
        }

        [TestMethod]
        public void UpdateSupplierInvoice()
        {
            var supplierInvoicePayment = GetSupplierInvoicePayment(invoiceNumber: "1", amount: "200", number: "17");

            var supplierInvoicePaymentUpdateResponse = _connector.Update(supplierInvoicePayment);
            Assert.AreEqual(supplierInvoicePaymentUpdateResponse.Amount, "200");

            supplierInvoicePayment = GetSupplierInvoicePayment(invoiceNumber: "1", amount: "100", number: "17");
            supplierInvoicePaymentUpdateResponse = _connector.Update(supplierInvoicePayment);
            Assert.AreEqual(supplierInvoicePaymentUpdateResponse.Amount, "100");
        }


        SupplierInvoicePayment GetSupplierInvoicePayment(string invoiceNumber, string amount, string number)
        {
            return new SupplierInvoicePayment
            {
                InvoiceNumber = invoiceNumber,
                Amount = amount,
                Number = number
            };
        }
    }
}

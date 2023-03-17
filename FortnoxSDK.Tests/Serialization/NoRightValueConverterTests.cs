using Fortnox.SDK.Entities;
using Fortnox.SDK.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxSDK.Tests.Serialization
{
    [TestClass]
    public class NoRightValueConverterTests
    {
        [TestMethod]
        public void Test_Parse_Invoice()
        {
            // Arrange
            var responseJson = @"{
                ""Comments"": ""TestInvoice"",
                ""ContractReference"": null,
                ""ContributionPercent"": 0.5,
                ""ContributionValue"": ""API_NORIGHT"",
                ""Country"": null,
                ""CostCenter"": null,
                ""Currency"": null,
                ""CustomerNumber"": ""123467254"",
                ""DocumentNumber"": null,
                ""DueDate"": ""2019-02-20T00:00:00"",
                ""HouseWork"": null,
                ""InvoiceDate"": ""2019-01-20T00:00:00"",
                ""InvoicePeriodStart"": null,
                ""InvoicePeriodEnd"": null,
                ""InvoiceReference"": null,
                ""InvoiceRows"": [
                {
                    ""ArticleNumber"": ""12427"",
                    ""DeliveredQuantity"": 10.0,
                    ""Price"": 100.0,
                }
                ],
                ""InvoiceType"": 4,
                ""PaymentWay"": 0,
                ""TotalToPay"": 0.0
            }";

            // Act
            var invoice = JsonConvert.DeserializeObject<Invoice>(responseJson, new NoRightValueConverter());

            // Assert both real value and 
            Assert.AreEqual(null, invoice.ContributionValue);
            Assert.AreEqual(0.5m, invoice.ContributionPercent);
        }
    }
}

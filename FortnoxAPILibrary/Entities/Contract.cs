using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Contract
    {
        /// <remarks/>
        [JsonProperty]
        public string Active { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string AdministrationFee { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Comments { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Continuous { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ContractDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ContractLength { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string ContributionPercent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string ContributionValue { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DocumentNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public ContractEmailInformation EmailInformation { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceReference1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceReference2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Freight { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string Gross { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string HouseWork { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceDiscount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceInterval { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string InvoicesRemaining { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public List<InvoiceRow> InvoiceRows { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Language { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string LastInvoiceDate { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string Net { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string OurReference { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PeriodEnd { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PeriodStart { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PriceList { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PrintTemplate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Remarks { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string TaxReduction { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string TemplateName { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string TemplateNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string Total { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string TotalToPay { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string TotalVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string VATIncluded { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string YourOrderNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string url { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string urlTaxReductionList { get; set; }

        /// <remarks/>
        public Contract()
        {
            InvoiceRows = new List<InvoiceRow>();
        }
    }

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ContractEmailInformation
    {
        /// <remarks/>
        [JsonProperty]
        public string EmailAddressFrom { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailAddressTo { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailAddressCC { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailAddressBCC { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailSubject { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailBody { get; set; }
    }
}

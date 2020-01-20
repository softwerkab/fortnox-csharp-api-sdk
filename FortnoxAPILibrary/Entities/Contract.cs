using System.Collections.Generic;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Contract", PluralName = "Contracts")]
    public class Contract 
    {
        /// <remarks/>
        [JsonProperty]
        public bool? Active { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? AdministrationFee { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Comments { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? Continuous { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ContractDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? ContractLength { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public double? ContributionPercent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public double? ContributionValue { get; private set; }

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
        public double? Freight { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public double? Gross { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public bool? HouseWork { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public double? InvoiceDiscount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? InvoiceInterval { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public int? InvoicesRemaining { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public List<InvoiceRow> InvoiceRows { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Language { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public string LastInvoiceDate { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public double? Net { get; private set; }

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
        [ReadOnly]
        [JsonProperty]
        public double? TaxReduction { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
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
        [ReadOnly]
        [JsonProperty]
        public double? Total { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public double? TotalToPay { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public double? TotalVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public bool? VATIncluded { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string YourOrderNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }

        /// <remarks/>
        public Contract()
        {
            InvoiceRows = new List<InvoiceRow>();
        }
    }

    /// <remarks/>
    [Entity(SingularName = "Contract", PluralName = "Contracts")]
    public class ContractSubset
    {
        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? Continuous { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? ContractLength { get; set; }

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
        public int? InvoiceInterval { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? InvoicesRemaining { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string LastInvoiceDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PeriodStart { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PeriodEnd { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Status { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TemplateNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? Total { get; set; }
    }

    /// <remarks/>
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

using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    public class Contract
    {
        /// <remarks/>
        public string Active { get; set; }

        /// <remarks/>
        public string AdministrationFee { get; set; }

        /// <remarks/>
        public string Comments { get; set; }

        /// <remarks/>
        public string Continuous { get; set; }

        /// <remarks/>
        public string ContractDate { get; set; }

        /// <remarks/>
        public string ContractLength { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string ContributionPercent { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string ContributionValue { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <remarks/>
        public string Currency { get; set; }

        /// <remarks/>
        public string CustomerName { get; set; }

        /// <remarks/>
        public string CustomerNumber { get; set; }

        /// <remarks/>
        public string DocumentNumber { get; set; }

        /// <remarks/>
        public ContractEmailInformation EmailInformation { get; set; }

        /// <remarks/>
        public string ExternalInvoiceReference1 { get; set; }

        /// <remarks/>
        public string ExternalInvoiceReference2 { get; set; }

        /// <remarks/>
        public string Freight { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Gross { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string HouseWork { get; set; }

        /// <remarks/>
        public string InvoiceDiscount { get; set; }

        /// <remarks/>
        public string InvoiceInterval { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string InvoicesRemaining { get; set; }

        /// <remarks/>
        public List<InvoiceRow> InvoiceRows { get; set; }

        /// <remarks/>
        public string Language { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string LastInvoiceDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Net { get; set; }

        /// <remarks/>
        public string OurReference { get; set; }

        /// <remarks/>
        public string PeriodEnd { get; set; }

        /// <remarks/>
        public string PeriodStart { get; set; }

        /// <remarks/>
        public string PriceList { get; set; }

        /// <remarks/>
        public string PrintTemplate { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <remarks/>
        public string Remarks { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string TaxReduction { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string TemplateName { get; set; }

        /// <remarks/>
        public string TemplateNumber { get; set; }

        /// <remarks/>
        public string TermsOfDelivery { get; set; }

        /// <remarks/>
        public string TermsOfPayment { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Total { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string TotalToPay { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string TotalVAT { get; set; }

        /// <remarks/>
        public string VATIncluded { get; set; }

        /// <remarks/>
        public string WayOfDelivery { get; set; }

        /// <remarks/>
        public string YourOrderNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true), XmlAttribute]
        public string url { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true), XmlAttribute]
        public string urlTaxReductionList { get; set; }

        /// <remarks/>
        public Contract()
        {
            InvoiceRows = new List<InvoiceRow>();
        }
    }

    /// <remarks/>
    public class ContractEmailInformation
    {
        /// <remarks/>
        public string EmailAddressFrom { get; set; }

        /// <remarks/>
        public string EmailAddressTo { get; set; }

        /// <remarks/>
        public string EmailAddressCC { get; set; }

        /// <remarks/>
        public string EmailAddressBCC { get; set; }

        /// <remarks/>
        public string EmailSubject { get; set; }

        /// <remarks/>
        public string EmailBody { get; set; }
    }
}

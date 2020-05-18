using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Contract", PluralName = "Contracts")]
    public class Contract
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Direct url to the tax reduction list for the record </summary>
        [ReadOnly]
        [JsonProperty("@urlTaxReductionList")]
        public string UrlTaxReductionList { get; private set; }

        ///<summary> If the contract is active </summary>
        [JsonProperty]
        public bool? Active { get; set; }

        ///<summary> Administration Fee </summary>
        [JsonProperty]
        public decimal? AdministrationFee { get; set; }

        ///<summary> Comments </summary>
        [JsonProperty]
        public string Comments { get; set; }

        ///<summary> If the contract is continuous </summary>
        [JsonProperty]
        public bool? Continuous { get; set; }

        ///<summary> Contract date </summary>
        [JsonProperty]
        public DateTime? ContractDate { get; set; }

        ///<summary> Contract length </summary>
        [JsonProperty]
        public int? ContractLength { get; set; }

        ///<summary> Contribution percent </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? ContributionPercent { get; private set; }

        ///<summary> Contribution value </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? ContributionValue { get; private set; }

        ///<summary> Cost center code </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Currency </summary>
        [JsonProperty]
        public string Currency { get; set; }

        ///<summary> Customer name </summary>
        [ReadOnly]
        [JsonProperty]
        public string CustomerName { get; private set; }

        ///<summary> Customer number </summary>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        ///<summary> Document number </summary>
        [JsonProperty]
        public int? DocumentNumber { get; set; }

        ///<summary> – </summary>
        [JsonProperty]
        public EmailInformation EmailInformation { get; set; }

        ///<summary> External invoice reference </summary>
        [JsonProperty]
        public string ExternalInvoiceReference1 { get; set; }

        ///<summary> External invoice reference </summary>
        [JsonProperty]
        public string ExternalInvoiceReference2 { get; set; }

        ///<summary> Freight </summary>
        [JsonProperty]
        public decimal? Freight { get; set; }

        ///<summary> Gross </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Gross { get; private set; }

        ///<summary> If house work </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? HouseWork { get; private set; }

        ///<summary> Invoice discount </summary>
        [JsonProperty]
        public decimal? InvoiceDiscount { get; set; }

        ///<summary> Invoice interval </summary>
        [JsonProperty]
        public int? InvoiceInterval { get; set; }

        ///<summary> – </summary>
        [JsonProperty]
        public List<ContractInvoiceRow> InvoiceRows { get; set; }

        ///<summary> Invoices remaining </summary>
        [ReadOnly]
        [JsonProperty]
        public int? InvoicesRemaining { get; private set; }

        ///<summary> Language </summary>
        [JsonProperty]
        public Language? Language { get; set; }

        ///<summary> Last invoice date </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? LastInvoiceDate { get; private set; }

        ///<summary> Net </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Net { get; private set; }

        ///<summary> Our reference </summary>
        [JsonProperty]
        public string OurReference { get; set; }

        ///<summary> End of the period </summary>
        [JsonProperty]
        public DateTime? PeriodEnd { get; set; }

        ///<summary> Start of the period </summary>
        [JsonProperty]
        public DateTime? PeriodStart { get; set; }

        ///<summary> Price list </summary>
        [JsonProperty]
        public string PriceList { get; set; }

        ///<summary> Project number </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Remarks </summary>
        [JsonProperty]
        public string Remarks { get; set; }

        ///<summary> Tax reduction </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? TaxReduction { get; private set; }

        ///<summary> Template name </summary>
        [ReadOnly]
        [JsonProperty]
        public string TemplateName { get; private set; }

        ///<summary> Template number </summary>
        [JsonProperty]
        public int? TemplateNumber { get; set; }

        ///<summary> Terms of delivery code </summary>
        [JsonProperty]
        public string TermsOfDelivery { get; set; }

        ///<summary> Terms of payment code </summary>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        ///<summary> Total </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Total { get; private set; }

        ///<summary> Total to pay </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? TotalToPay { get; private set; }

        ///<summary> Total VAT </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? TotalVAT { get; private set; }

        ///<summary> If VAT is included </summary>
        [JsonProperty]
        public bool? VATIncluded { get; set; }

        ///<summary> Way of delivery code </summary>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        ///<summary> Your order number </summary>
        [JsonProperty]
        public string YourOrderNumber { get; set; }
    }
}
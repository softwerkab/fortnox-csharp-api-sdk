using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Invoice", PluralName = "Invoices")]
    public class Invoice
    {
        ///<summary> Direct url to the record. </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Direct url to the tax reduction for the invoice. This is visible even if no tax reduction exists. </summary>
        [ReadOnly]
        [JsonProperty("@urlTaxReductionList")]
        public string UrlTaxReductionList { get; private set; }

        ///<summary> Accounting Method. Can be ACCRUAL or CASH </summary>
        [ReadOnly]
        [JsonProperty]
        public AccountingMethod? AccountingMethod { get; private set; }

        ///<summary> The invoice administration fee. </summary>
        [JsonProperty]
        public decimal? AdministrationFee { get; set; }

        ///<summary> VAT of the invoice administration fee. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? AdministrationFeeVAT { get; private set; }

        ///<summary> Invoice address 1. </summary>
        [JsonProperty]
        public string Address1 { get; set; }

        ///<summary> Invoice address 2. </summary>
        [JsonProperty]
        public string Address2 { get; set; }

        ///<summary> Balance of the invoice. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Balance { get; private set; }

        ///<summary> Basis of tax reduction. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? BasisTaxReduction { get; private set; }

        ///<summary> If the invoice is bookkept. This value can be changed by using the action “bookkeep”. </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Booked { get; private set; }

        ///<summary> If the invoice is cancelled. This value can be changed by using the action “cancel”. </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Cancelled { get; private set; }

        ///<summary> If the invoice is a credit invoice. </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Credit { get; private set; }

        ///<summary> Reference to the credit invoice, if one exits. The reference must be a document number for an existing credit invoice. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? CreditInvoiceReference { get; private set; }

        ///<summary> City for the invoice address. </summary>
        [JsonProperty]
        public string City { get; set; }

        ///<summary> Comments of the invoice </summary>
        [JsonProperty]
        public string Comments { get; set; }

        ///<summary> Reference to the contract, if one exists. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? ContractReference { get; private set; }

        ///<summary> Invoice contribution in percent. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? ContributionPercent { get; private set; }

        ///<summary> Invoice contribution in amount. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? ContributionValue { get; private set; }

        ///<summary> Country for the invoice address. Must be a name of an existing country. </summary>
        [JsonProperty]
        public string Country { get; set; }

        ///<summary> Code of the cost center. The code must be of an existing cost center. </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Code of the currency. The code must be of an existing currency. </summary>
        [JsonProperty]
        public string Currency { get; set; }

        ///<summary> Currency rate used for the invoice. </summary>
        [JsonProperty]
        public decimal? CurrencyRate { get; set; }

        ///<summary> Currency unit used for the invoice. </summary>
        [JsonProperty]
        public decimal? CurrencyUnit { get; set; }

        ///<summary> Name of the customer. </summary>
        [JsonProperty]
        public string CustomerName { get; set; }

        ///<summary> Customer number of the customer. The customer number must be of an existing customer. </summary>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        ///<summary> Invoice delivery address 1. </summary>
        [JsonProperty]
        public string DeliveryAddress1 { get; set; }

        ///<summary> Invoice delivery address 2. </summary>
        [JsonProperty]
        public string DeliveryAddress2 { get; set; }

        ///<summary> City for the invoice delivery address. </summary>
        [JsonProperty]
        public string DeliveryCity { get; set; }

        ///<summary> Country for the invoice delivery address. Must be a name of an existing country. </summary>
        [JsonProperty]
        public string DeliveryCountry { get; set; }

        ///<summary> Date of delivery. Must be a valid date according to our date format. </summary>
        [JsonProperty]
        public DateTime? DeliveryDate { get; set; }

        ///<summary> Name of the recipient of the delivery </summary>
        [JsonProperty]
        public string DeliveryName { get; set; }

        ///<summary> ZipCode for the invoice delivery address. </summary>
        [JsonProperty]
        public string DeliveryZipCode { get; set; }

        ///<summary> The invoice number. If no document number is provided, the next number in the series will be used. </summary>
        [JsonProperty]
        public int? DocumentNumber { get; set; }

        ///<summary> Due date of the invoice. Must be a valid date according to our date format. </summary>
        [JsonProperty]
        public DateTime? DueDate { get; set; }

        ///<summary> The properties for this object is listed in the table for “EDI Information”. </summary>
        [JsonProperty]
        public EDIInformation EDIInformation { get; set; }

        ///<summary> The properties for this object is listed in the table for “Email Information”. </summary>
        [JsonProperty]
        public EmailInformation EmailInformation { get; set; }

        ///<summary> EU Quarterly Report On / Off </summary>
        [JsonProperty]
        public bool? EUQuarterlyReport { get; set; }

        ///<summary> External invoice reference 1. </summary>
        [JsonProperty]
        public string ExternalInvoiceReference1 { get; set; }

        ///<summary> External invoice reference 2. </summary>
        [JsonProperty]
        public string ExternalInvoiceReference2 { get; set; }

        ///<summary> The date when the invoice became fully paid. Only available if the invoice is fully paid. </summary>
        [JsonProperty]
        public DateTime? FinalPayDate { get; set; }

        ///<summary> Freight cost of the invoice. </summary>
        [JsonProperty]
        public decimal? Freight { get; set; }

        ///<summary> VAT of the freight cost. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? FreightVAT { get; private set; }

        ///<summary> Gross value of the invoice </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Gross { get; private set; }

        ///<summary> If there is any row of the invoice marked “house work”. </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? HouseWork { get; private set; }

        ///<summary> Invoice date. Must be a valid date according to our date format. </summary>
        [JsonProperty]
        public DateTime? InvoiceDate { get; set; }

        ///<summary> Start date of the invoice period, only applicable for contract invoices. </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? InvoicePeriodStart { get; private set; }

        ///<summary> End date of the invoice period, only applicable for contract invoices. </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? InvoicePeriodEnd { get; private set; }

        ///<summary> The properties for the object in this array is listed in the table “Invoice Rows”. </summary>
        [JsonProperty]
        public List<InvoiceRow> InvoiceRows { get; set; }

        ///<summary> The type of invoice.</summary>
        [JsonProperty]
        public InvoiceType? InvoiceType { get; set; }

        ///<summary> The properties for the object in this array is listed in the table “Labels” </summary>
        [JsonProperty]
        public List<Label> Labels { get; set; }

        ///<summary> Language code. Can be SV or EN. </summary>
        [JsonProperty]
        public Language? Language { get; set; }

        ///<summary> Date of last reminder. </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? LastRemindDate { get; private set; }

        ///<summary> Net amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Net { get; private set; }

        ///<summary> If the invoice is set as not completed. </summary>
        [JsonProperty]
        public bool? NotCompleted { get; set; }

        ///<summary> If the invoice is managed by NoxFinans </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? NoxFinans { get; private set; }

        ///<summary> OCR number of the invoice. </summary>
        [JsonProperty]
        public string OCR { get; set; }

        ///<summary> Reference to the offer, if one exists. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? OfferReference { get; private set; }

        ///<summary> Reference to the order, if one exists. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? OrderReference { get; private set; }

        ///<summary> Organisation number of the customer for the invoice. </summary>
        [ReadOnly]
        [JsonProperty]
        public string OrganisationNumber { get; private set; }

        ///<summary> Our reference. </summary>
        [JsonProperty]
        public string OurReference { get; set; }

        ///<summary> CASH, CARD, AG </summary>
        [JsonProperty]
        public PaymentWay? PaymentWay { get; set; }

        ///<summary> Phone number 1 of the customer for the invoice. </summary>
        [JsonProperty]
        public string Phone1 { get; set; }

        ///<summary> Phone number 2 of the customer for the invoice. </summary>
        [JsonProperty]
        public string Phone2 { get; set; }

        ///<summary> Code of the price list. The code must be of an existing price list. </summary>
        [JsonProperty]
        public string PriceList { get; set; }

        ///<summary> Print template of the invoice. Must be an existing print template. </summary>
        [JsonProperty]
        public string PrintTemplate { get; set; }

        ///<summary> Code of the project. The code must be of an existing project. </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Remarks of the invoice. This is the invoice text shown on the invoice. </summary>
        [JsonProperty]
        public string Remarks { get; set; }

        ///<summary> Number of reminders sent to the customer. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Reminders { get; private set; }

        ///<summary> Round off amount for the invoice. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? RoundOff { get; private set; }

        ///<summary> If the document is printed or sent in any way. </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Sent { get; private set; }

        ///<summary> The amount of tax reduction. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? TaxReduction { get; private set; }

        ///<summary> Code of the terms of delivery. The code must be of an existing terms of delivery. </summary>
        [JsonProperty]
        public string TermsOfDelivery { get; set; }

        ///<summary> Code of the terms of payment. The code must be of an existing terms of payment. </summary>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        ///<summary> The total amount of the invoice. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Total { get; private set; }

        ///<summary> The total VAT amount of the invoice. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? TotalVAT { get; private set; }

        ///<summary> If the price of the invoice is including VAT. </summary>
        [JsonProperty]
        public bool? VATIncluded { get; set; }

        ///<summary> Voucher number for the invoice. This is created when the invoice is bookkept. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? VoucherNumber { get; private set; }

        ///<summary> Voucher series for the invoice. This is created when the invoice is bookkept. </summary>
        [ReadOnly]
        [JsonProperty]
        public string VoucherSeries { get; private set; }

        ///<summary> Voucher year for the invoice. This is created when the invoice is bookkept. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? VoucherYear { get; private set; }

        ///<summary> Code of the way of delivery. The code must be of an existing way of delivery. </summary>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        ///<summary> Your order number. </summary>
        [JsonProperty]
        public string YourOrderNumber { get; set; }

        ///<summary> Your reference. </summary>
        [JsonProperty]
        public string YourReference { get; set; }

        ///<summary> Zip code of the invoice. </summary>
        [JsonProperty]
        public string ZipCode { get; set; }
    }
}
using System.Collections.Generic;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "Invoice", PluralName = "Invoices")]
	public class Invoice 
	{
        /// <remarks/>
        public Invoice()
        {
            InvoiceRows = new List<InvoiceRow>();
            Labels = new List<Label>();
        }

		/// <remarks/>
		[JsonProperty]
		public double? AdministrationFee { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public double? AdministrationFeeVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Address1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Address2 { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public double? Balance { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public double? BasisTaxReduction { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public bool? Booked { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public bool? Cancelled { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string City { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Comments { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ContractReference { get; set; }

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
        public string Country { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public bool? Credit { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public string CreditInvoiceReference { get; private set; }

		/// <remarks/>
		[JsonProperty]
		public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? CurrencyRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? CurrencyUnit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryAddress1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryAddress2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryCity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryCountry { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryZipCode { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DocumentNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DueDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public InvoiceEDIInformation EDIInformation { get; set; }

        /// <remarks/>
        [JsonProperty]
        public InvoiceEmailInformation EmailInformation { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? EUQuarterlyReport { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? Freight { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public double? FreightVAT { get; private set; }

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
        public string InvoiceDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public string InvoicePeriodStart { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public string InvoicePeriodEnd { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public string InvoiceReference { get; private set; }

		/// <remarks/>
		[JsonProperty]
		public List<InvoiceRow> InvoiceRows { get; set; }

        /// <remarks/>
        [JsonProperty]
        public List<Label> Labels { get; set; }

        /// <remarks/>
        [JsonProperty]
        public InvoiceType? InvoiceType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Language { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string LastRemindDate { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public double? Net { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public bool? NotCompleted { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OCR { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string OfferReference { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string OrderReference { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string OrganisationNumber { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string OurReference { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PaymentWay { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Phone1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Phone2 { get; set; }

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
		public int? Reminders { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public double? RoundOff { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public bool? Sent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public int? TaxReduction { get; private set; }

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
		public string TotalToPay { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public double? TotalVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceReference1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceReference2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? VATIncluded { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string VoucherNumber { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string VoucherSeries { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public int? VoucherYear { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string YourOrderNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string YourReference { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ZipCode { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty(PropertyName = "@urlTaxReductionList")]
		public string UrlTaxReductionList { get; private set; }

        /// <remarks/>
	    [ReadOnly]
	    [JsonProperty]
	    public bool? NoxFinans { get; private set; }
    }

	/// <remarks/>
	public class InvoiceEDIInformation
	{
		/// <remarks/>
		[JsonProperty]
		public string EDIGlobalLocationNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EDIGlobalLocationNumberDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EDIInvoiceExtra1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EDIInvoiceExtra2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EDIOurElectronicReference { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EDIYourElectronicReference { get; set; }

        /// <remarks/>
        [ReadOnly]
        [JsonProperty]
        public string EDIStatus { get; private set; }
    }

    /// <remarks/>
	public class InvoiceEmailInformation
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

	/// <remarks/>
	public class InvoiceRow
	{
	    /// <remarks/>
		[JsonProperty]
		public string AccountNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ArticleNumber { get; set; }

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
        public double? DeliveredQuantity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? Discount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public DiscountType? DiscountType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? HouseWork { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string HouseWorkHoursToReport{ get; set; }

        /// <remarks/>
        [JsonProperty]
        public string HouseWorkType { get; set; }

	   /// <remarks/>
	    [JsonProperty]
	    public double? Price { get; set; }

        /// <remarks/>
        [ReadOnly]
        [JsonProperty]
        public double? PriceExcludingVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public double? Total { get; private set; }

        /// <remarks/>
        [ReadOnly]
        [JsonProperty]
        public double? TotalExcludingVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Unit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? VAT { get; set; }
    }

    /// <remarks/>
    [Entity(SingularName = "Invoice", PluralName = "Invoices")]
    public class InvoiceSubset
    {
        /// <remarks/>
        [JsonProperty]
        public double? Balance { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? Booked { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? Cancelled { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? CurrencyRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? CurrencyUnit { get; set; }

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
        public string DueDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceReference1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceReference2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? NoxFinans { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OCR { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? Sent { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? Total { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; private set; }
    }

    /// <remarks/>
    public enum DiscountType
    {
        /// <remarks/>
        AMOUNT,
        /// <remarks/>
        PERCENT
    }

    /// <remarks/>
    public enum InvoiceType
    {
        /// <remarks/>
        INVOICE,
        /// <remarks/>
        CASHINVOICE,
        /// <remarks/>
        INTRESTINVOICE,
        /// <remarks/>
        AGREEMENTINVOICE,
        /// <remarks/>
        SUMMARYINVOICE
    }
}

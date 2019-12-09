using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

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
		public string AdministrationFee { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string AdministrationFeeVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Address1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Address2 { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Balance { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string BasisTaxReduction { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Booked { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Cancelled { get; private set; }

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
		[JsonProperty]
		public string ContributionPercent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string ContributionValue { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Country { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Credit { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string CreditInvoiceReference { get; private set; }

		/// <remarks/>
		[JsonProperty]
		public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrencyRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrencyUnit { get; set; }

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
        public string EUQuarterlyReport { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Freight { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string FreightVAT { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Gross { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string HouseWork { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string InvoicePeriodStart { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string InvoicePeriodEnd { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
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
		[JsonProperty]
		public string LastRemindDate { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Net { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string NotCompleted { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OCR { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string OfferReference { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string OrderReference { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
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
		[JsonProperty]
		public string Reminders { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string RoundOff { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Sent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string TaxReduction { get; private set; }

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
        public string ExternalInvoiceReference1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceReference2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VATIncluded { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherNumber { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherSeries { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherYear { get; private set; }

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
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@urlTaxReductionList")]
		public string UrlTaxReductionList { get; private set; }

        /// <remarks/>
	    [JsonProperty]
	    public string NoxFinans { get; private set; }
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
        public string DeliveredQuantity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Discount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public DiscountType? DiscountType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string HouseWork { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string HouseWorkHoursToReport{ get; set; }

        /// <remarks/>
        [JsonProperty]
        public string HouseWorkType { get; set; }

	   /// <remarks/>
	    [JsonProperty]
	    public string Price { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PriceExcludingVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Total { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string TotalExcludingVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Unit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VAT { get; set; }
    }

    /// <remarks/>
    [Entity(SingularName = "Invoice", PluralName = "Invoices")]
    public class InvoiceSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string Balance { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Booked { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Cancelled { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrencyRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrencyUnit { get; set; }

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
        public string NoxFinans { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OCR { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Sent { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Total { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
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

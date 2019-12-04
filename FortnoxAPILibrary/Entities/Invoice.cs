using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
    [XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class Invoice
	{
        /// <remarks/>
        public Invoice()
        {
            InvoiceRows = new List<InvoiceRow>();
            Labels = new List<Label>();
        }

		/// <remarks/>
		public string AdministrationFee { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        /// [ReadOnly(true)]
        public string AdministrationFeeVAT { get; set; }

        /// <remarks/>
        public string Address1 { get; set; }

        /// <remarks/>
        public string Address2 { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Balance { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string BasisTaxReduction { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Booked { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Cancelled { get; set; }

        /// <remarks/>
        public string City { get; set; }

        /// <remarks/>
        public string Comments { get; set; }

        /// <remarks/>
        public string ContractReference { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string ContributionPercent { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string ContributionValue { get; set; }

        /// <remarks/>
        public string Country { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Credit { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string CreditInvoiceReference { get; set; }

		/// <remarks/>
		public string Currency { get; set; }

        /// <remarks/>
        public string CurrencyRate { get; set; }

        /// <remarks/>
        public string CurrencyUnit { get; set; }

        /// <remarks/>
        public string CustomerName { get; set; }

        /// <remarks/>
        public string CustomerNumber { get; set; }

        /// <remarks/>
        public string DeliveryAddress1 { get; set; }

        /// <remarks/>
        public string DeliveryAddress2 { get; set; }

        /// <remarks/>
        public string DeliveryCity { get; set; }

        /// <remarks/>
        public string DeliveryCountry { get; set; }

        /// <remarks/>
        public string DeliveryDate { get; set; }

        /// <remarks/>
        public string DeliveryName { get; set; }

        /// <remarks/>
        public string DeliveryZipCode { get; set; }

        /// <remarks/>
        public string DocumentNumber { get; set; }

        /// <remarks/>
        public string DueDate { get; set; }

        /// <remarks/>
        public InvoiceEDIInformation EDIInformation { get; set; }

        /// <remarks/>
        public InvoiceEmailInformation EmailInformation { get; set; }

        /// <remarks/>
        public string EUQuarterlyReport { get; set; }

        /// <remarks/>
        public string Freight { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string FreightVAT { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Gross { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string HouseWork { get; set; }

        /// <remarks/>
        public string InvoiceDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string InvoicePeriodStart { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string InvoicePeriodEnd { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string InvoiceReference { get; set; }

		/// <remarks/>
		public List<InvoiceRow> InvoiceRows { get; set; }

        /// <remarks/>
        public List<Label> Labels { get; set; }

        /// <remarks/>
        public InvoiceConnector.InvoiceType InvoiceType { get; set; }

        /// <remarks/>
        public string Language { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string LastRemindDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Net { get; set; }

        /// <remarks/>
        public string NotCompleted { get; set; }

        /// <remarks/>
        public string OCR { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string OfferReference { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string OrderReference { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string OrganisationNumber { get; set; }

        /// <remarks/>
        public string OurReference { get; set; }

        /// <remarks/>
        public string PaymentWay { get; set; }

        /// <remarks/>
        public string Phone1 { get; set; }

        /// <remarks/>
        public string Phone2 { get; set; }

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
		public string Reminders { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string RoundOff { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Sent { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string TaxReduction { get; set; }

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
        public string ExternalInvoiceReference1 { get; set; }

        /// <remarks/>
        public string ExternalInvoiceReference2 { get; set; }

        /// <remarks/>
        public string VATIncluded { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherYear { get; set; }

        /// <remarks/>
        public string WayOfDelivery { get; set; }

        /// <remarks/>
        public string YourOrderNumber { get; set; }

        /// <remarks/>
        public string YourReference { get; set; }

        /// <remarks/>
        public string ZipCode { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [XmlAttribute]
		[ReadOnly(true)]
		public string url { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [XmlAttribute]
		[ReadOnly(true)]
		public string urlTaxReductionList { get; set; }

        /// <remarks/>
        [ReadOnly(true)]
	    public string NoxFinans { get; set; }
    }

	/// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	public class InvoiceEDIInformation
	{
		/// <remarks/>
		public string EDIGlobalLocationNumber { get; set; }

        /// <remarks/>
        public string EDIGlobalLocationNumberDelivery { get; set; }

        /// <remarks/>
        public string EDIInvoiceExtra1 { get; set; }

        /// <remarks/>
        public string EDIInvoiceExtra2 { get; set; }

        /// <remarks/>
        public string EDIOurElectronicReference { get; set; }

        /// <remarks/>
        public string EDIYourElectronicReference { get; set; }
    }

	/// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	public class InvoiceEmailInformation
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

	/// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	public class InvoiceRow
	{
	    /// <remarks/>
		public string AccountNumber { get; set; }

        /// <remarks/>
        public string ArticleNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string ContributionPercent { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string ContributionValue { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <remarks/>
        public string DeliveredQuantity { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Discount { get; set; }

        /// <remarks/>
        public InvoiceConnector.DiscountType DiscountType { get; set; }

        /// <remarks/>
        public string HouseWork { get; set; }

        /// <remarks/>
        public string HouseWorkHoursToReport{ get; set; }

        /// <remarks/>
        public string HouseWorkType { get; set; }

	   /// <remarks/>
	    public string Price { get; set; }

        /// <remarks/>
        [ReadOnly(true)]
        public string PriceExcludingVAT { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Total { get; set; }

        /// <remarks/>
        [ReadOnly(true)]
        public string TotalExcludingVAT { get; set; }

        /// <remarks/>
        public string Unit { get; set; }

        /// <remarks/>
        public string VAT { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class Label //TODO Merge with other Label class
    {
        /// <remarks/>
        public string Id { get; set; }
    }
}

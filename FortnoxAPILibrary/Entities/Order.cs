using System;
using System.Collections.Generic;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	public class Order
	{
        /// <remarks/>
        public Order()
        {
            OrderRows = new List<OrderRow>();
            Labels = new List<Label>();
        }

		/// <remarks/>
		public string AdministrationFee { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string AdministrationFeeVAT { get; private set; }

        /// <remarks/>
        public string Address1 { get; set; }

        /// <remarks/>
        public string Address2 { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string BasisTaxReduction { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Cancelled { get; private set; }

        /// <remarks/>
        public string City { get; set; }

        /// <remarks/>
        public string Comments { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string ContributionPercent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string ContributionValue { get; private set; }

        /// <remarks/>
        public string CopyRemarks { get; set; }

        /// <remarks/>
        public string Country { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

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
        public OrderEmailInformation EmailInformation { get; set; }

        /// <remarks/>
        public string ExternalInvoiceReference1 { get; set; }

        /// <remarks/>
        public string ExternalInvoiceReference2 { get; set; }

        /// <remarks/>
        public string Freight { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string FreightVAT { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Gross { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string HouseWork { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string InvoiceReference { get; private set; }

        /// <remarks/>
        public string Language { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Net { get; private set; }

        /// <remarks/>
        public string NotCompleted { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string OfferReference { get; private set; }

        /// <remarks/>
        public string OrderDate { get; set; }

        /// <remarks/>
        public List<OrderRow> OrderRows { get; set; }

        /// <remarks/>
        public List<Label> Labels { get; set; }

        /// <remarks/>
        public string OrganisationNumber { get; set; }

        /// <remarks/>
        public string OurReference { get; set; }

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
		public string RoundOff { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Sent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string TaxReduction { get; private set; }

        /// <remarks/>
        public string TermsOfDelivery { get; set; }

        /// <remarks/>
        public string TermsOfPayment { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Total { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string TotalToPay { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string TotalVAT { get; private set; }

        /// <remarks/>
        public string VATIncluded { get; set; }

        /// <remarks/>
        public string WayOfDelivery { get; set; }

        /// <remarks/>
        public string YourReference { get; set; }

        /// <remarks/>
        public string YourOrderNumber { get; set; }

        /// <remarks/>
        public string ZipCode { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string url { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string urlTaxReductionList { get; private set; }
    }

	/// <remarks/>
	
	
	
	public class OrderEmailInformation
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
	public class OrderRow
	{
		/// <remarks/>
		public string AccountNumber { get; set; }

        /// <remarks/>
        public string ArticleNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string ContributionPercent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string ContributionValue { get; private set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <remarks/>
        public string DeliveredQuantity { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Discount { get; set; }

        /// <remarks/>
        public OrderConnector.DiscountType DiscountType { get; set; }

        /// <remarks/>
        public string HouseWork { get; set; }

        /// <remarks/>
        public string OrderedQuantity { get; set; }

        /// <remarks/>
        public string Price { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Total { get; private set; }

        /// <remarks/>
        public string Unit { get; set; }

        /// <remarks/>
        public string VAT { get; set; }
    }
}

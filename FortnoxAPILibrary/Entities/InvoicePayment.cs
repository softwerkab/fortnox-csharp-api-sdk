﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Denna kod har genererats av ett verktyg.
//     Körtidsversion:2.0.50727.5472
//
//     Ändringar i denna fil kan orsaka fel och kommer att förloras om
//     koden återgenereras.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;
using System.Collections.Generic;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 

namespace FortnoxAPILibrary
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class InvoicePayment
	{

		private string amountField;

		private string amountCurrencyField;

		private string bookedField;

		private string currencyField;

		private string currencyRateField;

		private string currencyUnitField;

		private string externalInvoiceReference1Field;

		private string externalInvoiceReference2Field;

		private string invoiceCustomerNameField;

		private string invoiceCustomerNumberField;

		private string invoiceNumberField;

		private string invoiceDueDateField;

		private string invoiceOCRField;

		private string invoiceTotalField;

		private string modeOfPaymentField;

		private string numberField;

		private string paymentDateField;

		private string sourceField;

		private string voucherNumberField;

		private string voucherSeriesField;

		private string voucherYearField;

		private List<InvoiceWriteOff> writeOffsField;

		private string urlField;

        private string modeOfPaymentAccount;

        /// <remarks/>
        public string Amount
		{
			get
			{
				return this.amountField;
			}
			set
			{
				this.amountField = value;
			}
		}

		/// <remarks/>
		public string AmountCurrency
		{
			get
			{
				return this.amountCurrencyField;
			}
			set
			{
				this.amountCurrencyField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string Booked
		{
			get
			{
				return this.bookedField;
			}
			set
			{
				this.bookedField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string Currency
		{
			get
			{
				return this.currencyField;
			}
			set
			{
				this.currencyField = value;
			}
		}

		/// <remarks/>
		public string CurrencyRate
		{
			get
			{
				return this.currencyRateField;
			}
			set
			{
				this.currencyRateField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string CurrencyUnit
		{
			get
			{
				return this.currencyUnitField;
			}
			set
			{
				this.currencyUnitField = value;
			}
		}


		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string ExternalInvoiceReference1
		{
			get
			{
				return this.externalInvoiceReference1Field;
			}
			set
			{
				this.externalInvoiceReference1Field = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string ExternalInvoiceReference2
		{
			get
			{
				return this.externalInvoiceReference2Field;
			}
			set
			{
				this.externalInvoiceReference2Field = value;
			}
		}


		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string InvoiceCustomerName
		{
			get
			{
				return this.invoiceCustomerNameField;
			}
			set
			{
				this.invoiceCustomerNameField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string InvoiceCustomerNumber
		{
			get
			{
				return this.invoiceCustomerNumberField;
			}
			set
			{
				this.invoiceCustomerNumberField = value;
			}
		}

		/// <remarks/>
		public string InvoiceNumber
		{
			get
			{
				return this.invoiceNumberField;
			}
			set
			{
				this.invoiceNumberField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string InvoiceDueDate
		{
			get
			{
				return this.invoiceDueDateField;
			}
			set
			{
				this.invoiceDueDateField = value;
			}
		}

		/// <remarks/>
		public string InvoiceOCR
		{
			get
			{
				return this.invoiceOCRField;
			}
			set
			{
				this.invoiceOCRField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string InvoiceTotal
		{
			get
			{
				return this.invoiceTotalField;
			}
			set
			{
				this.invoiceTotalField = value;
			}
		}

		/// <remarks/>
		public string ModeOfPayment
		{
			get
			{
				return this.modeOfPaymentField;
			}
			set
			{
				this.modeOfPaymentField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string Number
		{
			get
			{
				return this.numberField;
			}
			set
			{
				this.numberField = value;
			}
		}

		/// <remarks/>
		public string PaymentDate
		{
			get
			{
				return this.paymentDateField;
			}
			set
			{
				this.paymentDateField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string Source
		{
			get
			{
				return this.sourceField;
			}
			set
			{
				this.sourceField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string VoucherNumber
		{
			get
			{
				return this.voucherNumberField;
			}
			set
			{
				this.voucherNumberField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string VoucherSeries
		{
			get
			{
				return this.voucherSeriesField;
			}
			set
			{
				this.voucherSeriesField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string VoucherYear
		{
			get
			{
				return this.voucherYearField;
			}
			set
			{
				this.voucherYearField = value;
			}
		}

		/// <remarks/>
		//[System.Xml.Serialization.XmlElementAttribute("WriteOffs", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public List<InvoiceWriteOff> WriteOffs
		{
			get
			{
				return this.writeOffsField;
			}
			set
			{
				this.writeOffsField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.ReadOnly(true)]
		public string @url
		{
			get
			{
				return this.urlField;
			}
			set
			{
				this.urlField = value;
			}
		}

        public string ModeOfPaymentAccount
        {
            get
            {
                return this.modeOfPaymentAccount;
            }
            set
            {
                this.modeOfPaymentAccount = value;
            }
        }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	
	public partial class InvoiceWriteOff
	{

		private string amountField;

		private string accountNumberField;

		private string costCenterField;

		private string currencyField;

		private string descriptionField;

		private string transactionInformationField;

		private string projectField;

		/// <remarks/>
		public string Amount
		{
			get
			{
				return this.amountField;
			}
			set
			{
				this.amountField = value;
			}
		}

		/// <remarks/>
		public string AccountNumber
		{
			get
			{
				return this.accountNumberField;
			}
			set
			{
				this.accountNumberField = value;
			}
		}

		/// <remarks/>
		public string CostCenter
		{
			get
			{
				return this.costCenterField;
			}
			set
			{
				this.costCenterField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string Currency
		{
			get
			{
				return this.currencyField;
			}
			set
			{
				this.currencyField = value;
			}
		}

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		public string Description
		{
			get
			{
				return this.descriptionField;
			}
			set
			{
				this.descriptionField = value;
			}
		}

		/// <remarks/>
		public string TransactionInformation
		{
			get
			{
				return this.transactionInformationField;
			}
			set
			{
				this.transactionInformationField = value;
			}
		}

		/// <remarks/>
		public string Project
		{
			get
			{
				return this.projectField;
			}
			set
			{
				this.projectField = value;
			}
		}

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class InvoicePaymentConnector : FinancialYearBasedEntityConnector<InvoicePayment, InvoicePayments, Sort.By.InvoicePayment>
	{
		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string InvoiceNumber { get; set; }

		/// <remarks/>
		public InvoicePaymentConnector()
		{
			base.Resource = "invoicepayments";
		}

		/// <summary>
		/// Gets an invoice payment
		/// </summary>
		/// <param name="number">The number of the invoice payment to find</param>
		/// <returns>The found invoice payment</returns>
		public InvoicePayment Get(string number)
		{
			return base.BaseGet(number);
		}

		/// <summary>
		/// Updates an invoice payment
		/// </summary>
		/// <param name="invoicePayment">The invoice payment to update</param>
		/// <returns>The updated invoice payment</returns>
		public InvoicePayment Update(InvoicePayment invoicePayment)
		{
			return base.BaseUpdate(invoicePayment, invoicePayment.Number.ToString());
		}

		/// <summary>
		/// Create a new invoice payment
		/// </summary>
		/// <param name="invoicePayment">The invoice payment to be created</param>
		/// <returns>The created invoice payment</returns>
		public InvoicePayment Create(InvoicePayment invoicePayment)
		{
			return base.BaseCreate(invoicePayment);
		}

		/// <summary>
		/// Deletes a payment
		/// </summary>
		/// <param name="number">The number of the payment to delete</param>
		public void Delete(string number)
		{
			base.BaseDelete(number);
		}

		/// <summary>
		/// Gets a list of payments
		/// </summary>
		/// <returns>A list of payments</returns>
		public InvoicePayments Find()
		{
			return base.BaseFind();
		}

		/// <summary>
		/// Bookkeep an invoice payment
		/// </summary>
		/// <param name="invoicePaymentNumber">The number of the invoice payment to bookkeep.</param>
		public void Bookkeep(string invoicePaymentNumber)
		{
			base.DoAction(invoicePaymentNumber, "bookkeep");
		}
	}
}

using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class InvoicePaymentConnector : EntityConnector<InvoicePayment, EntityCollection<InvoicePaymentSubset>, Sort.By.InvoicePayment?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.InvoicePayment? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string InvoiceNumber { get; set; }

		/// <remarks/>
		public InvoicePaymentConnector()
		{
			Resource = "invoicepayments";
		}

		/// <summary>
		/// Find a invoicePayment based on id
		/// </summary>
		/// <param name="id">Identifier of the invoicePayment to find</param>
		/// <returns>The found invoicePayment</returns>
		public InvoicePayment Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a invoicePayment
		/// </summary>
		/// <param name="invoicePayment">The invoicePayment to update</param>
		/// <returns>The updated invoicePayment</returns>
		public InvoicePayment Update(InvoicePayment invoicePayment)
		{
			return BaseUpdate(invoicePayment, invoicePayment.Number.ToString());
		}

		/// <summary>
		/// Creates a new invoicePayment
		/// </summary>
		/// <param name="invoicePayment">The invoicePayment to create</param>
		/// <returns>The created invoicePayment</returns>
		public InvoicePayment Create(InvoicePayment invoicePayment)
		{
			return BaseCreate(invoicePayment);
		}

		/// <summary>
		/// Deletes a invoicePayment
		/// </summary>
		/// <param name="id">Identifier of the invoicePayment to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of invoicePayments
		/// </summary>
		/// <returns>A list of invoicePayments</returns>
		public EntityCollection<InvoicePaymentSubset> Find()
		{
			return BaseFind();
		}
	}
}

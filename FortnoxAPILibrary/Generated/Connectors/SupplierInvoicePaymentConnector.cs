using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoicePaymentConnector : EntityConnector<SupplierInvoicePayment, EntityCollection<SupplierInvoicePaymentSubset>, Sort.By.SupplierInvoicePayment?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.SupplierInvoicePayment? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string InvoiceNumber { get; set; }

		/// <remarks/>
		public SupplierInvoicePaymentConnector()
		{
			Resource = "supplierinvoicepayments";
		}

		/// <summary>
		/// Find a supplierInvoicePayment based on id
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoicePayment to find</param>
		/// <returns>The found supplierInvoicePayment</returns>
		public SupplierInvoicePayment Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a supplierInvoicePayment
		/// </summary>
		/// <param name="supplierInvoicePayment">The supplierInvoicePayment to update</param>
		/// <returns>The updated supplierInvoicePayment</returns>
		public SupplierInvoicePayment Update(SupplierInvoicePayment supplierInvoicePayment)
		{
			return BaseUpdate(supplierInvoicePayment, supplierInvoicePayment.Id.ToString());
		}

		/// <summary>
		/// Creates a new supplierInvoicePayment
		/// </summary>
		/// <param name="supplierInvoicePayment">The supplierInvoicePayment to create</param>
		/// <returns>The created supplierInvoicePayment</returns>
		public SupplierInvoicePayment Create(SupplierInvoicePayment supplierInvoicePayment)
		{
			return BaseCreate(supplierInvoicePayment);
		}

		/// <summary>
		/// Deletes a supplierInvoicePayment
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoicePayment to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of supplierInvoicePayments
		/// </summary>
		/// <returns>A list of supplierInvoicePayments</returns>
		public EntityCollection<SupplierInvoicePaymentSubset> Find()
		{
			return BaseFind();
		}
	}
}

using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoicePaymentConnector : EntityConnector<SupplierInvoicePayment, EntityCollection<SupplierInvoicePaymentSubset>, Sort.By.SupplierInvoicePayment?>, ISupplierInvoicePaymentConnector
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
		public SupplierInvoicePayment Get(int? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a supplierInvoicePayment
		/// </summary>
		/// <param name="supplierInvoicePayment">The supplierInvoicePayment to update</param>
		/// <returns>The updated supplierInvoicePayment</returns>
		public SupplierInvoicePayment Update(SupplierInvoicePayment supplierInvoicePayment)
		{
			return UpdateAsync(supplierInvoicePayment).Result;
		}

		/// <summary>
		/// Creates a new supplierInvoicePayment
		/// </summary>
		/// <param name="supplierInvoicePayment">The supplierInvoicePayment to create</param>
		/// <returns>The created supplierInvoicePayment</returns>
		public SupplierInvoicePayment Create(SupplierInvoicePayment supplierInvoicePayment)
		{
			return CreateAsync(supplierInvoicePayment).Result;
		}

		/// <summary>
		/// Deletes a supplierInvoicePayment
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoicePayment to delete</param>
		public void Delete(int? id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of supplierInvoicePayments
		/// </summary>
		/// <returns>A list of supplierInvoicePayments</returns>
		public EntityCollection<SupplierInvoicePaymentSubset> Find()
		{
			return FindAsync().Result;
		}

		/// <summary>
		/// Bookkeeps the supplier invoice payment
		/// </summary>
		/// <param name="id"></param>
		public void Bookkeep(int? id)
        {
            DoAction(id.ToString(), Action.Bookkeep);
        }

		public async Task<EntityCollection<SupplierInvoicePaymentSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(int? id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<SupplierInvoicePayment> CreateAsync(SupplierInvoicePayment supplierInvoicePayment)
		{
			return await BaseCreate(supplierInvoicePayment);
		}
		public async Task<SupplierInvoicePayment> UpdateAsync(SupplierInvoicePayment supplierInvoicePayment)
		{
			return await BaseUpdate(supplierInvoicePayment, supplierInvoicePayment.Number.ToString());
		}
		public async Task<SupplierInvoicePayment> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
	}
}

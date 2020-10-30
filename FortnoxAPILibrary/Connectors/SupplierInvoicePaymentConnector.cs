using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoicePaymentConnector : SearchableEntityConnector<SupplierInvoicePayment, SupplierInvoicePaymentSubset>, ISupplierInvoicePaymentConnector
	{
		public SupplierInvoicePaymentSearch Search { get; set; } = new SupplierInvoicePaymentSearch();

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
		public SupplierInvoicePayment Get(long? id)
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
		public void Delete(long? id)
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
		public void Bookkeep(long? id)
        {
            DoAction(id.ToString(), Action.Bookkeep);
        }

		public async Task<EntityCollection<SupplierInvoicePaymentSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task DeleteAsync(long? id)
		{
			await BaseDelete(id.ToString()).ConfigureAwait(false);
		}
		public async Task<SupplierInvoicePayment> CreateAsync(SupplierInvoicePayment supplierInvoicePayment)
		{
			return await BaseCreate(supplierInvoicePayment).ConfigureAwait(false);
		}
		public async Task<SupplierInvoicePayment> UpdateAsync(SupplierInvoicePayment supplierInvoicePayment)
		{
			return await BaseUpdate(supplierInvoicePayment, supplierInvoicePayment.Number.ToString()).ConfigureAwait(false);
		}
		public async Task<SupplierInvoicePayment> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}
	}
}

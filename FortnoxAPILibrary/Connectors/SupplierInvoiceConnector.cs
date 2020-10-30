using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceConnector : SearchableEntityConnector<SupplierInvoice, SupplierInvoiceSubset>, ISupplierInvoiceConnector
	{
		public SupplierInvoiceSearch Search { get; set; } = new SupplierInvoiceSearch();


		/// <remarks/>
		public SupplierInvoiceConnector()
		{
			Resource = "supplierinvoices";
		}

		/// <summary>
		/// Find a supplierInvoice based on id
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoice to find</param>
		/// <returns>The found supplierInvoice</returns>
		public SupplierInvoice Get(long? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a supplierInvoice
		/// </summary>
		/// <param name="supplierInvoice">The supplierInvoice to update</param>
		/// <returns>The updated supplierInvoice</returns>
		public SupplierInvoice Update(SupplierInvoice supplierInvoice)
		{
			return UpdateAsync(supplierInvoice).Result;
		}

		/// <summary>
		/// Creates a new supplierInvoice
		/// </summary>
		/// <param name="supplierInvoice">The supplierInvoice to create</param>
		/// <returns>The created supplierInvoice</returns>
		public SupplierInvoice Create(SupplierInvoice supplierInvoice)
		{
			return CreateAsync(supplierInvoice).Result;
		}

		/// <summary>
		/// Gets a list of supplierInvoices
		/// </summary>
		/// <returns>A list of supplierInvoices</returns>
		public EntityCollection<SupplierInvoiceSubset> Find()
		{
			return FindAsync().Result;
		}
		
		/// <summary>
		/// Bookkeeps the supplier invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public SupplierInvoice Bookkeep(long? id)
		{
			return DoAction(id.ToString(), Action.Bookkeep);
		}
		
		/// <summary>
		/// Cancels the supplier invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public SupplierInvoice Cancel(long? id)
		{
			return DoAction(id.ToString(), Action.Cancel);
		}
		
		/// <summary>
		/// Creates a credit of the supplier invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public SupplierInvoice Credit(long? id)
		{
			return DoAction(id.ToString(), Action.Credit);
		}
		
		/// <summary>
		/// Approval of payment of the supplier invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public SupplierInvoice ApprovalPayment(long? id)
		{
			return DoAction(id.ToString(), Action.ApprovalPayment);
		}
		
		/// <summary>
		/// Approval of bookkeep of the supplier invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public SupplierInvoice ApprovalBookkeep(long? id)
		{
			return DoAction(id.ToString(), Action.ApprovalBookkeep);
		}

		public async Task<EntityCollection<SupplierInvoiceSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task<SupplierInvoice> CreateAsync(SupplierInvoice supplierInvoice)
		{
			return await BaseCreate(supplierInvoice).ConfigureAwait(false);
		}
		public async Task<SupplierInvoice> UpdateAsync(SupplierInvoice supplierInvoice)
		{
			return await BaseUpdate(supplierInvoice, supplierInvoice.GivenNumber.ToString()).ConfigureAwait(false);
		}
		public async Task<SupplierInvoice> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}
	}
}

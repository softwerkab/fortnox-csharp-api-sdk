using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceConnector : SearchableEntityConnector<SupplierInvoice, SupplierInvoiceSubset, SupplierInvoiceSearch>, ISupplierInvoiceConnector
	{


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
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a supplierInvoice
		/// </summary>
		/// <param name="supplierInvoice">The supplierInvoice to update</param>
		/// <returns>The updated supplierInvoice</returns>
		public SupplierInvoice Update(SupplierInvoice supplierInvoice)
		{
			return UpdateAsync(supplierInvoice).GetResult();
		}

		/// <summary>
		/// Creates a new supplierInvoice
		/// </summary>
		/// <param name="supplierInvoice">The supplierInvoice to create</param>
		/// <returns>The created supplierInvoice</returns>
		public SupplierInvoice Create(SupplierInvoice supplierInvoice)
		{
			return CreateAsync(supplierInvoice).GetResult();
		}

		/// <summary>
		/// Gets a list of supplierInvoices
		/// </summary>
		/// <returns>A list of supplierInvoices</returns>
		public EntityCollection<SupplierInvoiceSubset> Find(SupplierInvoiceSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}
		
		/// <summary>
		/// Bookkeeps the supplier invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public SupplierInvoice Bookkeep(long? id)
        {
            return BookkeepAsync(id).GetResult();
        }
		
		/// <summary>
		/// Cancels the supplier invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public SupplierInvoice Cancel(long? id)
        {
            return CancelAsync(id).GetResult();
        }
		
		/// <summary>
		/// Creates a credit of the supplier invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public SupplierInvoice Credit(long? id)
        {
            return CreditAsync(id).GetResult();
        }
		
		/// <summary>
		/// Approval of payment of the supplier invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public SupplierInvoice ApprovalPayment(long? id)
        {
            return ApprovalPaymentAsync(id).GetResult();
        }
		
		/// <summary>
		/// Approval of bookkeep of the supplier invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public SupplierInvoice ApprovalBookkeep(long? id)
        {
            return ApprovalBookkeepAsync(id).GetResult();
        }

		public async Task<EntityCollection<SupplierInvoiceSubset>> FindAsync(SupplierInvoiceSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
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

        public async Task<SupplierInvoice> BookkeepAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.Bookkeep).ConfigureAwait(false);
        }
		
        public async Task<SupplierInvoice> CancelAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.Cancel).ConfigureAwait(false);
		}
		
        public async Task<SupplierInvoice> CreditAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.Credit).ConfigureAwait(false);
		}

        public async Task<SupplierInvoice> ApprovalPaymentAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.ApprovalPayment).ConfigureAwait(false);
		}

        public async Task<SupplierInvoice> ApprovalBookkeepAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.ApprovalBookkeep).ConfigureAwait(false);
		}
	}
}

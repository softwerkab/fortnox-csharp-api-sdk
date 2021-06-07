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
    internal class InvoiceAccrualConnector : SearchableEntityConnector<InvoiceAccrual, InvoiceAccrualSubset, InvoiceAccrualSearch>, IInvoiceAccrualConnector
	{


		/// <remarks/>
		public InvoiceAccrualConnector()
		{
			Resource = "invoiceaccruals";
		}

        /// <summary>
        /// Find a invoiceAccrual based on id
        /// </summary>
        /// <param name="id">Identifier of the invoiceAccrual to find</param>
        /// <returns>The found invoiceAccrual</returns>
        public InvoiceAccrual Get(long? id)
        {
			return GetAsync(id).GetResult();
        }

        /// <summary>
        /// Updates a invoiceAccrual
        /// </summary>
        /// <param name="invoiceAccrual">The invoiceAccrual to update</param>
        /// <returns>The updated invoiceAccrual</returns>
        public InvoiceAccrual Update(InvoiceAccrual invoiceAccrual)
        {
			return UpdateAsync(invoiceAccrual).GetResult();
        }

        /// <summary>
        /// Creates a new invoiceAccrual
        /// </summary>
        /// <param name="invoiceAccrual">The invoiceAccrual to create</param>
        /// <returns>The created invoiceAccrual</returns>
        public InvoiceAccrual Create(InvoiceAccrual invoiceAccrual)
        {
			return CreateAsync(invoiceAccrual).GetResult();
        }

        /// <summary>
        /// Deletes a invoiceAccrual
        /// </summary>
        /// <param name="id">Identifier of the invoiceAccrual to delete</param>
        public void Delete(long? id)
        {
			DeleteAsync(id).GetResult();
        }

        /// <summary>
        /// Gets a list of invoiceAccruals
        /// </summary>
        /// <returns>A list of invoiceAccruals</returns>
        public EntityCollection<InvoiceAccrualSubset> Find(InvoiceAccrualSearch searchSettings)
        {
			return FindAsync(searchSettings).GetResult();
        }

        public async Task<EntityCollection<InvoiceAccrualSubset>> FindAsync(InvoiceAccrualSearch searchSettings)
        {
            return await BaseFind(searchSettings).ConfigureAwait(false);
        }
        public async Task DeleteAsync(long? id)
        {
            await BaseDelete(id.ToString()).ConfigureAwait(false);
        }
        public async Task<InvoiceAccrual> CreateAsync(InvoiceAccrual invoiceAccrual)
        {
            return await BaseCreate(invoiceAccrual).ConfigureAwait(false);
        }
        public async Task<InvoiceAccrual> UpdateAsync(InvoiceAccrual invoiceAccrual)
        {
            return await BaseUpdate(invoiceAccrual, invoiceAccrual.InvoiceNumber.ToString()).ConfigureAwait(false);
        }
        public async Task<InvoiceAccrual> GetAsync(long? id)
        {
            return await BaseGet(id.ToString()).ConfigureAwait(false);
        }
    }
}

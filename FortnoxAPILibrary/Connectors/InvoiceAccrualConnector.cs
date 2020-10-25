using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class InvoiceAccrualConnector : EntityConnector<InvoiceAccrual, EntityCollection<InvoiceAccrualSubset>, Sort.By.InvoiceAccrual?>, IInvoiceAccrualConnector
	{
		public InvoiceAccrualSearch Search { get; set; } = new InvoiceAccrualSearch();


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
			return GetAsync(id).Result;
        }

        /// <summary>
        /// Updates a invoiceAccrual
        /// </summary>
        /// <param name="invoiceAccrual">The invoiceAccrual to update</param>
        /// <returns>The updated invoiceAccrual</returns>
        public InvoiceAccrual Update(InvoiceAccrual invoiceAccrual)
        {
			return UpdateAsync(invoiceAccrual).Result;
        }

        /// <summary>
        /// Creates a new invoiceAccrual
        /// </summary>
        /// <param name="invoiceAccrual">The invoiceAccrual to create</param>
        /// <returns>The created invoiceAccrual</returns>
        public InvoiceAccrual Create(InvoiceAccrual invoiceAccrual)
        {
			return CreateAsync(invoiceAccrual).Result;
        }

        /// <summary>
        /// Deletes a invoiceAccrual
        /// </summary>
        /// <param name="id">Identifier of the invoiceAccrual to delete</param>
        public void Delete(long? id)
        {
			DeleteAsync(id).Wait();
        }

        /// <summary>
        /// Gets a list of invoiceAccruals
        /// </summary>
        /// <returns>A list of invoiceAccruals</returns>
        public EntityCollection<InvoiceAccrualSubset> Find()
        {
			return FindAsync().Result;
        }

        public async Task<EntityCollection<InvoiceAccrualSubset>> FindAsync()
        {
            return await BaseFind().ConfigureAwait(false);
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

using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class InvoiceAccrualConnector : EntityConnector<InvoiceAccrual, EntityCollection<InvoiceAccrualSubset>, Sort.By.InvoiceAccrual?>, IInvoiceAccrualConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.InvoiceAccrual? FilterBy { get; set; }


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
        public InvoiceAccrual Get(int? id)
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
        public void Delete(int? id)
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
            return await BaseFind();
        }
        public async Task DeleteAsync(int? id)
        {
            await BaseDelete(id.ToString());
        }
        public async Task<InvoiceAccrual> CreateAsync(InvoiceAccrual invoiceAccrual)
        {
            return await BaseCreate(invoiceAccrual);
        }
        public async Task<InvoiceAccrual> UpdateAsync(InvoiceAccrual invoiceAccrual)
        {
            return await BaseUpdate(invoiceAccrual, invoiceAccrual.InvoiceNumber.ToString());
        }
        public async Task<InvoiceAccrual> GetAsync(int? id)
        {
            return await BaseGet(id.ToString());
        }
    }
}

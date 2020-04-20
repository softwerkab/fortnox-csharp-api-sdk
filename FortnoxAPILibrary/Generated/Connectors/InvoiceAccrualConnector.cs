using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

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
            return BaseGet(id.ToString());
        }

        /// <summary>
        /// Updates a invoiceAccrual
        /// </summary>
        /// <param name="invoiceAccrual">The invoiceAccrual to update</param>
        /// <returns>The updated invoiceAccrual</returns>
        public InvoiceAccrual Update(InvoiceAccrual invoiceAccrual)
        {
            return BaseUpdate(invoiceAccrual, invoiceAccrual.InvoiceNumber.ToString());
        }

        /// <summary>
        /// Creates a new invoiceAccrual
        /// </summary>
        /// <param name="invoiceAccrual">The invoiceAccrual to create</param>
        /// <returns>The created invoiceAccrual</returns>
        public InvoiceAccrual Create(InvoiceAccrual invoiceAccrual)
        {
            return BaseCreate(invoiceAccrual);
        }

        /// <summary>
        /// Deletes a invoiceAccrual
        /// </summary>
        /// <param name="id">Identifier of the invoiceAccrual to delete</param>
        public void Delete(int? id)
        {
            BaseDelete(id.ToString());
        }

        /// <summary>
        /// Gets a list of invoiceAccruals
        /// </summary>
        /// <returns>A list of invoiceAccruals</returns>
        public EntityCollection<InvoiceAccrualSubset> Find()
        {
            return BaseFind();
        }
    }
}

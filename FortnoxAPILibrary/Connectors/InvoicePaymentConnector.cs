using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class InvoicePaymentConnector : EntityConnector<InvoicePayment, EntityCollection<InvoicePaymentSubset>, Sort.By.InvoicePayment?>, IInvoicePaymentConnector
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
		public InvoicePayment Get(int? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a invoicePayment
		/// </summary>
		/// <param name="invoicePayment">The invoicePayment to update</param>
		/// <returns>The updated invoicePayment</returns>
		public InvoicePayment Update(InvoicePayment invoicePayment)
		{
			return UpdateAsync(invoicePayment).Result;
		}

		/// <summary>
		/// Creates a new invoicePayment
		/// </summary>
		/// <param name="invoicePayment">The invoicePayment to create</param>
		/// <returns>The created invoicePayment</returns>
		public InvoicePayment Create(InvoicePayment invoicePayment)
		{
			return CreateAsync(invoicePayment).Result;
		}

		/// <summary>
		/// Deletes a invoicePayment
		/// </summary>
		/// <param name="id">Identifier of the invoicePayment to delete</param>
		public void Delete(int? id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of invoicePayments
		/// </summary>
		/// <returns>A list of invoicePayments</returns>
		public EntityCollection<InvoicePaymentSubset> Find()
		{
			return FindAsync().Result;
		}

		/// <summary>
		/// Bookkeeps the invoice payment
		/// </summary>
		/// <param name="id"></param>
		public void Bookkeep(int? id)
        {
            DoAction(id.ToString(), Action.Bookkeep);
        }

		public async Task<EntityCollection<InvoicePaymentSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(int? id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<InvoicePayment> CreateAsync(InvoicePayment invoicePayment)
		{
			return await BaseCreate(invoicePayment);
		}
		public async Task<InvoicePayment> UpdateAsync(InvoicePayment invoicePayment)
		{
			return await BaseUpdate(invoicePayment, invoicePayment.Number.ToString());
		}
		public async Task<InvoicePayment> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
	}
}

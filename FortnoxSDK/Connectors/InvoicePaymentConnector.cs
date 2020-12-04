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
    public class InvoicePaymentConnector : SearchableEntityConnector<InvoicePayment, InvoicePaymentSubset, InvoicePaymentSearch>, IInvoicePaymentConnector
	{


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
		public InvoicePayment Get(long? id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a invoicePayment
		/// </summary>
		/// <param name="invoicePayment">The invoicePayment to update</param>
		/// <returns>The updated invoicePayment</returns>
		public InvoicePayment Update(InvoicePayment invoicePayment)
		{
			return UpdateAsync(invoicePayment).GetResult();
		}

		/// <summary>
		/// Creates a new invoicePayment
		/// </summary>
		/// <param name="invoicePayment">The invoicePayment to create</param>
		/// <returns>The created invoicePayment</returns>
		public InvoicePayment Create(InvoicePayment invoicePayment)
		{
			return CreateAsync(invoicePayment).GetResult();
		}

		/// <summary>
		/// Deletes a invoicePayment
		/// </summary>
		/// <param name="id">Identifier of the invoicePayment to delete</param>
		public void Delete(long? id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of invoicePayments
		/// </summary>
		/// <returns>A list of invoicePayments</returns>
		public EntityCollection<InvoicePaymentSubset> Find(InvoicePaymentSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		/// <summary>
		/// Bookkeeps the invoice payment
		/// </summary>
		/// <param name="id"></param>
		public void Bookkeep(long? id)
        {
            BookkeepAsync(id).GetResult();
        }

		public async Task<EntityCollection<InvoicePaymentSubset>> FindAsync(InvoicePaymentSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(long? id)
		{
			await BaseDelete(id.ToString()).ConfigureAwait(false);
		}
		public async Task<InvoicePayment> CreateAsync(InvoicePayment invoicePayment)
		{
			return await BaseCreate(invoicePayment).ConfigureAwait(false);
		}
		public async Task<InvoicePayment> UpdateAsync(InvoicePayment invoicePayment)
		{
			return await BaseUpdate(invoicePayment, invoicePayment.Number.ToString()).ConfigureAwait(false);
		}
		public async Task<InvoicePayment> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}

        public async Task BookkeepAsync(long? id)
        {
            await DoActionAsync(id.ToString(), Action.Bookkeep).ConfigureAwait(false);
        }
	}
}

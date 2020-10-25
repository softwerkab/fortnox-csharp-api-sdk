using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class InvoiceConnector : EntityConnector<Invoice, EntityCollection<InvoiceSubset>, Sort.By.Invoice?>, IInvoiceConnector
	{
		public InvoiceSearch Search { get; set; } = new InvoiceSearch();


		/// <remarks/>
		public InvoiceConnector()
		{
			Resource = "invoices";
		}

		/// <summary>
		/// Find a invoice based on id
		/// </summary>
		/// <param name="id">Identifier of the invoice to find</param>
		/// <returns>The found invoice</returns>
		public Invoice Get(long? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a invoice
		/// </summary>
		/// <param name="invoice">The invoice to update</param>
		/// <returns>The updated invoice</returns>
		public Invoice Update(Invoice invoice)
		{
			return UpdateAsync(invoice).Result;
		}

		/// <summary>
		/// Creates a new invoice
		/// </summary>
		/// <param name="invoice">The invoice to create</param>
		/// <returns>The created invoice</returns>
		public Invoice Create(Invoice invoice)
		{
			return CreateAsync(invoice).Result;
		}

        /// <summary>
		/// Gets a list of invoices
		/// </summary>
		/// <returns>A list of invoices</returns>
		public EntityCollection<InvoiceSubset> Find()
		{
			return FindAsync().Result;
		}
		
		/// <summary>
		/// Bookkeeps an invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice Bookkeep(long? id)
		{
			return DoAction(id.ToString(), Action.Bookkeep);
		}
		
		/// <summary>
		/// Cancels an invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice Cancel(long? id)
		{
			return DoAction(id.ToString(), Action.Cancel);
		}
		
		/// <summary>
		/// Creates a credit invoice from the provided invoice. The created credit invoice will be referenced in the property CreditInvoiceReference.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice CreditInvoice(long? id)
		{
			return DoAction(id.ToString(), Action.Credit);
		}
		
		/// <summary>
		/// Sends an e-mail to the customer with an attached PDF document of the invoice. You can use the properties in the EmailInformation to customize the e-mail message on each invoice.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice Email(long? id)
		{
			return DoAction(id.ToString(), Action.Email);
		}
		
		/// <summary>
		/// Sends an e-invoice to the customer with an attached PDF document of the invoice. Note that this action also sets the property Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice EInvoice(long? id)
		{
			return DoAction(id.ToString(), Action.EInvoice);
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Note that this action also sets the property Sent as true.
		/// <param name="id"></param>
        /// <returns></returns>
		/// </summary>
		public byte[] Print(long? id)
		{
			return DoDownloadAction(id.ToString(), Action.Print);
		}
		
		/// <summary>
		/// This action returns a PDF document with the current reminder template that is used by the specific document. Note that this action also sets the property Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] PrintReminder(long? id)
		{
			return DoDownloadAction(id.ToString(), Action.PrintReminder);
		}
		
		/// <summary>
		/// This action is used to set the field Sent as true from an external system without generating a PDF.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice ExternalPrint(long? id)
		{
			return DoAction(id.ToString(), Action.ExternalPrint);
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Unliike the action print, this action doesn’t set the property Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] Preview(long? id)
		{
			return DoDownloadAction(id.ToString(), Action.Preview);
		}

		public async Task<EntityCollection<InvoiceSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task<Invoice> CreateAsync(Invoice invoice)
		{
			return await BaseCreate(invoice).ConfigureAwait(false);
		}
		public async Task<Invoice> UpdateAsync(Invoice invoice)
		{
			return await BaseUpdate(invoice, invoice.DocumentNumber.ToString()).ConfigureAwait(false);
		}
		public async Task<Invoice> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}
	}
}

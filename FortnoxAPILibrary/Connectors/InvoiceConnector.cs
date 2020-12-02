using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class InvoiceConnector : SearchableEntityConnector<Invoice, InvoiceSubset, InvoiceSearch>, IInvoiceConnector
	{


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
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a invoice
		/// </summary>
		/// <param name="invoice">The invoice to update</param>
		/// <returns>The updated invoice</returns>
		public Invoice Update(Invoice invoice)
		{
			return UpdateAsync(invoice).GetResult();
		}

		/// <summary>
		/// Creates a new invoice
		/// </summary>
		/// <param name="invoice">The invoice to create</param>
		/// <returns>The created invoice</returns>
		public Invoice Create(Invoice invoice)
		{
			return CreateAsync(invoice).GetResult();
		}

        /// <summary>
		/// Gets a list of invoices
		/// </summary>
		/// <returns>A list of invoices</returns>
		public EntityCollection<InvoiceSubset> Find()
		{
			return FindAsync().GetResult();
		}
		
		/// <summary>
		/// Bookkeeps an invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice Bookkeep(long? id)
        {
            return BookkeepAsync(id).GetResult();
        }
		
		/// <summary>
		/// Cancels an invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice Cancel(long? id)
        {
            return CancelAsync(id).GetResult();
        }
		
		/// <summary>
		/// Creates a credit invoice from the provided invoice. The created credit invoice will be referenced in the property CreditInvoiceReference.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice CreditInvoice(long? id)
        {
            return CreditInvoiceAsync(id).GetResult();
        }
		
		/// <summary>
		/// Sends an e-mail to the customer with an attached PDF document of the invoice. You can use the properties in the EmailInformation to customize the e-mail message on each invoice.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice Email(long? id)
        {
            return EmailAsync(id).GetResult();
        }
		
		/// <summary>
		/// Sends an e-invoice to the customer with an attached PDF document of the invoice. Note that this action also sets the property Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice EInvoice(long? id)
        {
            return EInvoiceAsync(id).GetResult();
        }
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Note that this action also sets the property Sent as true.
		/// <param name="id"></param>
        /// <returns></returns>
		/// </summary>
		public byte[] Print(long? id)
        {
            return PrintAsync(id).GetResult();
        }
		
		/// <summary>
		/// This action returns a PDF document with the current reminder template that is used by the specific document. Note that this action also sets the property Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] PrintReminder(long? id)
        {
            return PrintReminderAsync(id).GetResult();
        }
		
		/// <summary>
		/// This action is used to set the field Sent as true from an external system without generating a PDF.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice ExternalPrint(long? id)
        {
            return ExternalPrintAsync(id).GetResult();
        }
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Unliike the action print, this action doesn’t set the property Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] Preview(long? id)
        {
            return PreviewAsync(id).GetResult();
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

        public async Task<Invoice> BookkeepAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.Bookkeep).ConfigureAwait(false);
		}

        public async Task<Invoice> CancelAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.Cancel).ConfigureAwait(false);
		}

        public async Task<Invoice> CreditInvoiceAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.Credit).ConfigureAwait(false);
		}

        public async Task<Invoice> EmailAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.Email).ConfigureAwait(false);
		}

        public async Task<Invoice> EInvoiceAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.EInvoice).ConfigureAwait(false);
		}

        public async Task<byte[]> PrintAsync(long? id)
        {
            return await DoDownloadActionAsync(id.ToString(), Action.Print).ConfigureAwait(false);
		}

        public async Task<byte[]> PrintReminderAsync(long? id)
        {
            return await DoDownloadActionAsync(id.ToString(), Action.PrintReminder).ConfigureAwait(false);
		}

        public async Task<Invoice> ExternalPrintAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.ExternalPrint).ConfigureAwait(false);
		}

        public async Task<byte[]> PreviewAsync(long? id)
        {
            return await DoDownloadActionAsync(id.ToString(), Action.Preview).ConfigureAwait(false);
		}
	}
}

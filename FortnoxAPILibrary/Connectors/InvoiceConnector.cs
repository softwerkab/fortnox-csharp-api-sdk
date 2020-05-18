using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class InvoiceConnector : EntityConnector<Invoice, EntityCollection<InvoiceSubset>, Sort.By.Invoice?>, IInvoiceConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Invoice? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Credit { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CostCenter { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Currency { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CustomerName { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CustomerNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string DocumentNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ExternalInvoiceReference1 { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ExternalInvoiceReference2 { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string InvoiceType { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string NotCompleted { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string OCR { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string OurReference { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Project { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Sent { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string YourOrderNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string YourReference { get; set; }

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
		public Invoice Get(int? id)
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
		public Invoice Bookkeep(int? id)
		{
			return DoAction(id.ToString(), Action.Bookkeep);
		}
		
		/// <summary>
		/// Cancels an invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice Cancel(int? id)
		{
			return DoAction(id.ToString(), Action.Cancel);
		}
		
		/// <summary>
		/// Creates a credit invoice from the provided invoice. The created credit invoice will be referenced in the property CreditInvoiceReference.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice CreditInvoice(int? id)
		{
			return DoAction(id.ToString(), Action.Credit);
		}
		
		/// <summary>
		/// Sends an e-mail to the customer with an attached PDF document of the invoice. You can use the properties in the EmailInformation to customize the e-mail message on each invoice.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice Email(int? id)
		{
			return DoAction(id.ToString(), Action.Email);
		}
		
		/// <summary>
		/// Sends an e-invoice to the customer with an attached PDF document of the invoice. Note that this action also sets the property Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice EInvoice(int? id)
		{
			return DoAction(id.ToString(), Action.EInvoice);
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Note that this action also sets the property Sent as true.
		/// <param name="id"></param>
        /// <returns></returns>
		/// </summary>
		public byte[] Print(int? id)
		{
			return DoDownloadAction(id.ToString(), Action.Print);
		}
		
		/// <summary>
		/// This action returns a PDF document with the current reminder template that is used by the specific document. Note that this action also sets the property Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] PrintReminder(int? id)
		{
			return DoDownloadAction(id.ToString(), Action.PrintReminder);
		}
		
		/// <summary>
		/// This action is used to set the field Sent as true from an external system without generating a PDF.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Invoice ExternalPrint(int? id)
		{
			return DoAction(id.ToString(), Action.ExternalPrint);
		}
		
		/// <summary>
		/// This action returns a PDF document with the current template that is used by the specific document. Unliike the action print, this action doesn’t set the property Sent as true.
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public byte[] Preview(int? id)
		{
			return DoDownloadAction(id.ToString(), Action.Preview);
		}

		public async Task<EntityCollection<InvoiceSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task<Invoice> CreateAsync(Invoice invoice)
		{
			return await BaseCreate(invoice);
		}
		public async Task<Invoice> UpdateAsync(Invoice invoice)
		{
			return await BaseUpdate(invoice, invoice.DocumentNumber.ToString());
		}
		public async Task<Invoice> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
	}
}

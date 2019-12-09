using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class InvoiceConnector : FinancialYearBasedEntityConnector<Invoice, EntityCollection<InvoiceSubset>, Sort.By.Invoice>
    {
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
        public string FromDate { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
        public string ToDate { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string CostCenter { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string CustomerName { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string CustomerNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string DocumentNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string ExternalInvoiceReference1 { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string ExternalInvoiceReference2 { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string OCR { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string OurReference { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
        public string InvoiceDate { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string Project { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string YourReference { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
        public string Label { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public bool? Sent { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public bool? NotCompleted { get; set; }

        /// <remarks/>
        [FilterProperty("filter")]
		public Filter.Invoice? FilterBy { get; set; }

        /// <remarks/>
		public InvoiceConnector()
		{
			Resource = "invoices";
		}

		/// <summary>
		/// Find an invoice
		/// </summary>
		/// <param name="documentNumber">The document number of the invoice to find</param>
		/// <returns>The found invoice</returns>
		public Invoice Get(string documentNumber)
		{
			return BaseGet(documentNumber);
		}

		/// <summary>
		/// Updates an Invoice
		/// </summary>
		/// <param name="invoice">The invoice to update</param>
		/// <returns>The updated invoice</returns>
		public Invoice Update(Invoice invoice)
		{
			return BaseUpdate(invoice, invoice.DocumentNumber);
		}

		/// <summary>
		/// Create a new invoice
		/// </summary>
		/// <param name="invoice">The invoice to create</param>
		/// <returns>The created invoice</returns>
		public Invoice Create(Invoice invoice)
		{
			return BaseCreate(invoice);
		}

        /// <summary>
        /// Gets at list of Invoices
        /// </summary>
        /// <returns>A list of invoices</returns>
        public EntityCollection<InvoiceSubset> Find()
		{
			return BaseFind();
		}

		/// <summary>
		/// Bookkeep an invoice
		/// </summary>
		/// <param name="documentNumber">The document number of the invoice to bookkeep.</param>
		/// <returns>The bookkept invoice</returns>
		public Invoice Bookkeep(string documentNumber)
		{
			return DoAction(documentNumber, "bookkeep");
		}

		/// <summary>
		/// Cancel an invoice
		/// </summary>
		/// <param name="documentNumber">The document number of the invoice to cancel</param>
		/// <returns>The cancelled invoice</returns>
		public Invoice Cancel(string documentNumber)
		{
			return DoAction(documentNumber, "cancel");
		}

		/// <summary>
		/// Credit an invoice
		/// </summary>
		/// <param name="documentNumber">The document number of the invoice to credit</param>
		/// <returns>The credited invoice</returns>
		public Invoice Credit(string documentNumber)
		{
			return DoAction(documentNumber, "credit");
		}

		/// <summary>
		/// Emails an invoice
		/// </summary>
		/// <param name="documentNumber">The document number of the invoice to be emailed</param>
		public void Email(string documentNumber)
		{
			DoAction(documentNumber, "email");
		}

		/// <summary>
		/// Print an invoice to pdf
		/// </summary>
		/// <param name="documentNumber">The document number of the invoice to print</param>
		/// <param name="localPath">The path where to save the generated pdf. If omitted the invoice will be set to printed (i.e Sent = true) and no pdf is returned. </param>
		public void Print(string documentNumber, string localPath = "")
		{
			if (string.IsNullOrEmpty(localPath))
			{
				DoAction(documentNumber, "externalprint");
			}
			else
			{
				LocalPath = localPath;
				DoAction(documentNumber, "print");
			}
		}
        
        /// <param name="documentNumber">The document number of the invoice to print</param>
        public void EPrint(string documentNumber)
        {
            DoAction(documentNumber, "eprint");
        }

		/// <summary>
		/// Prints a reminder to pdf and increments <Reminders></Reminders> on the invoice
		/// </summary>
		/// <param name="documentNumber"></param>
		/// <param name="localPath">The path where to save the reminder </param>
		public void PrintReminder(string documentNumber, string localPath)
		{
			LocalPath = localPath;
			DoAction(documentNumber, "printreminder");
		}

        /// <summary>
        /// Prints a preview as pdf
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <param name="localPath">The path where to save the preview</param>
        public void Preview(string documentNumber, string localPath)
        {
            LocalPath = localPath;
            DoAction(documentNumber, "preview");
        }

        /// <summary>
        /// Marks the document as externally printed
        /// </summary>
        /// <param name="documentNumber"></param>
        public void ExternalPrint(string documentNumber)
        {
            DoAction(documentNumber, "externalprint");
        }
	}
}

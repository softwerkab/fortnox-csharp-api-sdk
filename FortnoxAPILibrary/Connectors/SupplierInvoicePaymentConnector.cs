namespace FortnoxAPILibrary.Connectors
{
    public interface ISupplierInvoicePaymentConnector : IFinancialYearBasedEntityConnector<SupplierInvoicePayment, SupplierInvoicePayments, Sort.By.SupplierInvoicePayment>
    {
        /// <remarks/>
        string InvoiceNumber { get; set; }

        /// <summary>
        /// Create a new supplier invoice payment
        /// </summary>
        /// <param name="supplierInvoicePayment">The supplier invoice payment to be created</param>
        /// <returns>The created supplier invoice payment</returns>
        SupplierInvoicePayment Create(SupplierInvoicePayment supplierInvoicePayment);

        /// <summary>
        /// Updates an supplier invoice payment
        /// </summary>
        /// <param name="supplierInvoicePayment">The supplier invoice payment to update</param>
        /// <returns>The updated supplier invoice payment</returns>
        SupplierInvoicePayment Update(SupplierInvoicePayment supplierInvoicePayment);
        /// <summary>
        /// Gets a list of supplier payments
        /// </summary>
        /// <returns>A list of payments</returns>
        SupplierInvoicePayments Find();

        /// <summary>
        /// Gets a supplier invoice payment based on supplier invoice payment number
        /// </summary>
        /// <param name="supplierInvoicePaymentNumber">The supplier invoice payment number to find</param>
        /// <returns>The found supplier invoice payment</returns>
        SupplierInvoicePayment Get(string supplierInvoicePaymentNumber);

        /// <summary>
        /// Bookkeep a supplier invoice payment
        /// </summary>
        /// <param name="supplierInvoicePaymentNumber">The number of the supplier invoice payment to bookkeep.</param>
        void Bookkeep(string supplierInvoicePaymentNumber);

        /// <summary>
        /// Delete a supplier invoice payment
        /// </summary>
        /// <param name="supplierInvoicePaymentNumber">The number of the supplier invoice payment to delete.</param>
        public void Delete(string supplierInvoicePaymentNumber);
    }

    /// <remarks/>
	public class SupplierInvoicePaymentConnector : FinancialYearBasedEntityConnector<SupplierInvoicePayment, SupplierInvoicePayments, Sort.By.SupplierInvoicePayment>, ISupplierInvoicePaymentConnector
    {
        /// <remarks/>
        [FilterProperty]
        public string InvoiceNumber { get; set; }

		/// <remarks/>
		public SupplierInvoicePaymentConnector()
		{
			base.Resource = "supplierinvoicepayments";
		}

		/// <summary>
		/// Create a new supplier invoice payment
		/// </summary>
		/// <param name="supplierInvoicePayment">The supplier invoice payment to be created</param>
		/// <returns>The created supplier invoice payment</returns>
		public SupplierInvoicePayment Create(SupplierInvoicePayment supplierInvoicePayment)
		{
			return base.BaseCreate(supplierInvoicePayment);
		}

        /// <summary>
        /// Updates an supplier invoice payment
        /// </summary>
        /// <param name="supplierInvoicePayment">The supplier invoice payment to update</param>
        /// <returns>The updated supplier invoice payment</returns>
        public SupplierInvoicePayment Update(SupplierInvoicePayment supplierInvoicePayment)
        {
            return base.BaseUpdate(supplierInvoicePayment, supplierInvoicePayment.Number.ToString());
        }

        /// <summary>
		/// Gets a list of supplier payments
		/// </summary>
		/// <returns>A list of payments</returns>
		public SupplierInvoicePayments Find()
		{
			return base.BaseFind();
		}

        /// <summary>
        /// Gets a supplier invoice payment based on supplier invoice payment number
        /// </summary>
        /// <param name="supplierInvoicePaymentNumber">The supplier invoice payment number to find</param>
        /// <returns>The found supplier invoice payment</returns>
        public SupplierInvoicePayment Get(string supplierInvoicePaymentNumber)
        {
            return base.BaseGet(supplierInvoicePaymentNumber);
        }

		/// <summary>
		/// Bookkeep a supplier invoice payment
		/// </summary>
		/// <param name="supplierInvoicePaymentNumber">The number of the supplier invoice payment to bookkeep.</param>
		public void Bookkeep(string supplierInvoicePaymentNumber)
		{
			base.DoAction(supplierInvoicePaymentNumber, "bookkeep");
		}
		
		/// <summary>
		/// Delete a supplier invoice payment
		/// </summary>
		/// <param name="supplierInvoicePaymentNumber">The number of the supplier invoice payment to delete.</param>
		public void Delete(string supplierInvoicePaymentNumber)
		{
			base.BaseDelete(supplierInvoicePaymentNumber);
		}
	}
}

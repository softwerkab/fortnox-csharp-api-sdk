namespace FortnoxAPILibrary
{
    public class SupplierInvoicePaymentSearch : BaseSearch
    {
        [SearchParameter]
		public string InvoiceNumber { get; set; }
    }
}

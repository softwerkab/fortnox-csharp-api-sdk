namespace FortnoxAPILibrary
{
    public class SupplierInvoiceFileConnectionSearch : BaseSearch
    {
		[SearchParameter]
		public string SupplierInvoiceNumber { get; set; }
    }
}

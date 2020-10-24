namespace FortnoxAPILibrary
{
    public class SupplierInvoiceSearch : BaseSearch
    {
        [SearchParameter]
		public string CostCenter { get; set; }

        [SearchParameter]
		public string OCR { get; set; }

        [SearchParameter]
		public string Project { get; set; }

        [SearchParameter]
		public string SupplierNumber { get; set; }
    }
}

namespace FortnoxAPILibrary
{
    public class SupplierInvoiceSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.SupplierInvoice? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.SupplierInvoice? FilterBy { get; set; }


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

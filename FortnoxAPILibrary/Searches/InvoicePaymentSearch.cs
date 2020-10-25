namespace FortnoxAPILibrary
{
    public class InvoicePaymentSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.InvoicePayment? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.InvoicePayment? FilterBy { get; set; }


        [SearchParameter]
		public string InvoiceNumber { get; set; }
    }
}

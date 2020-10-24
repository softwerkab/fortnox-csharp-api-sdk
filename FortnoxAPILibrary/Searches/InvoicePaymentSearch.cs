namespace FortnoxAPILibrary
{
    public class InvoicePaymentSearch : BaseSearch
    {
        [SearchParameter]
		public string InvoiceNumber { get; set; }
    }
}

namespace FortnoxAPILibrary
{
    public class TaxReductionSearch : BaseSearch
    {
        [SearchParameter]
		public string ReferenceNumber { get; set; }
    }
}

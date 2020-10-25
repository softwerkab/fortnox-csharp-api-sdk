namespace FortnoxAPILibrary
{
    public class TaxReductionSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.TaxReduction? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.TaxReduction? FilterBy { get; set; }


        [SearchParameter]
		public string ReferenceNumber { get; set; }
    }
}

namespace FortnoxAPILibrary
{
    public class LabelSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.Label? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.Label? FilterBy { get; set; }


    }
}

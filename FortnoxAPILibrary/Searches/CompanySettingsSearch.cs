namespace FortnoxAPILibrary
{
    public class CompanySettingsSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.CompanySettings? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.CompanySettings? FilterBy { get; set; }


    }
}

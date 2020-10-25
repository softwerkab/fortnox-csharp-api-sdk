namespace FortnoxAPILibrary
{
    public class AssetTypesSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.AssetTypes? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.AssetTypes? FilterBy { get; set; }


    }
}

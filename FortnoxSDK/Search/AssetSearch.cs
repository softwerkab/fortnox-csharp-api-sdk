namespace Fortnox.SDK.Search
{
    public class AssetSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.Asset? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.Asset? FilterBy { get; set; }


        [SearchParameter]
		public string Description { get; set; }

        [SearchParameter]
		public string Type { get; set; }
    }
}

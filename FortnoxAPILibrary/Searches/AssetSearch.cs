namespace FortnoxAPILibrary
{
    public class AssetSearch : BaseSearch
    {
        [SearchParameter]
		public string Description { get; set; }

        [SearchParameter]
		public string Type { get; set; }
    }
}

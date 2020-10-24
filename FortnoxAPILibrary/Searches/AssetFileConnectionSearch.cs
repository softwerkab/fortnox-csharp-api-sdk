namespace FortnoxAPILibrary
{
    public class AssetFileConnectionSearch : BaseSearch
    {
        [SearchParameter]
		public string AssetId { get; set; }
    }
}

namespace Fortnox.SDK.Search;

public class AssetFileConnectionSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.AssetFileConnection? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.AssetFileConnection? FilterBy { get; set; }


    [SearchParameter]
    public string AssetId { get; set; }
}
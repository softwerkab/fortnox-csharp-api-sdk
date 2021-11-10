namespace Fortnox.SDK.Search;

public class ProjectSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.Project? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.Project? FilterBy { get; set; }


    [SearchParameter("description")]
    public string Description { get; set; }
}
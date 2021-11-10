namespace Fortnox.SDK.Search;

public class PrintTemplateSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.PrintTemplate? SortBy { get; set; }

    [SearchParameter("type")]
    public Filter.PrintTemplate? FilterBy { get; set; }
}
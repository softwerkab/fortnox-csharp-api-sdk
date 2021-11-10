namespace Fortnox.SDK.Search;

public class ContractTemplateSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.ContractTemplate? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.ContractTemplate? FilterBy { get; set; }


}
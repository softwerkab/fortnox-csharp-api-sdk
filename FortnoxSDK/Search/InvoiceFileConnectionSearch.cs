namespace Fortnox.SDK.Search;

public class InvoiceFileConnectionSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.InvoiceFileConnection? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.InvoiceFileConnection? FilterBy { get; set; }


}
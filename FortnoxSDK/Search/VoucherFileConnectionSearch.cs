namespace Fortnox.SDK.Search;

public class VoucherFileConnectionSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.VoucherFileConnection? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.VoucherFileConnection? FilterBy { get; set; }


    [SearchParameter]
    public string VoucherDescription { get; set; }

    [SearchParameter]
    public string VoucherNumber { get; set; }

    [SearchParameter]
    public string VoucherSeries { get; set; }
}
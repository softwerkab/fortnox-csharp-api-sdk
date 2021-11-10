namespace Fortnox.SDK.Search;

public class PredefinedVoucherSeriesSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.PredefinedVoucherSeries? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.PredefinedVoucherSeries? FilterBy { get; set; }


}
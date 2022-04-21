using System;

namespace Fortnox.SDK.Search;

public class FinancialYearSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.FinancialYear? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.FinancialYear? FilterBy { get; set; }

    [SearchParameter]
    public DateTime? Date { get; set; }

    [Obsolete("DO NOT USE! For filtering based on date, use Date property instead")]
    public override DateTime? FinancialYearDate { get; set; }
}
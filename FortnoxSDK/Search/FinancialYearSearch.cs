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

    [Obsolete("Use Date property instead")]
    public override DateTime? FinancialYearDate
    {
        get => Date;
        set => Date = value;
    }
}
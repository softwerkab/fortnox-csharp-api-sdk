using System;

namespace Fortnox.SDK.Search;

public class AttendanceTransactionsSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.AttendanceTransactions? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.AttendanceTransactions? FilterBy { get; set; }


    [SearchParameter("employeeid")]
    public string EmployeeId { get; set; }

    [SearchParameter("date")]
    public DateTime? Date { get; set; }
}
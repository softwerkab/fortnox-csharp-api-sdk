using System;

namespace FortnoxAPILibrary
{
    public class AttendanceTransactionsSearch : BaseSearch
    {
        [SearchParameter("employeeid")]
        public string EmployeeId { get; set; }

        [SearchParameter("date")]
        public DateTime? Date { get; set; }
    }
}

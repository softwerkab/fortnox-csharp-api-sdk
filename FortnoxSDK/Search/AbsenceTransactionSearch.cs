using System;

namespace Fortnox.SDK.Search
{
    public class AbsenceTransactionSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.AbsenceTransaction? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.AbsenceTransaction? FilterBy { get; set; }


		[SearchParameter("employeeid")]
		public string EmployeeId { get; set; }

        [SearchParameter("date")]
        public DateTime? Date { get; set; }
    }
}

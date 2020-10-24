using System;

namespace FortnoxAPILibrary
{
    public class BaseSearch
    {
        [SearchParameter]
        public DateTime? LastModified { get; set; }

        [SearchParameter("financialyear")]
        public long? FinancialYearID { get; set; }

        [SearchParameter]
        public DateTime? FinancialYearDate { get; set; }

        [SearchParameter]
        public DateTime? FromDate { get; set; }

        [SearchParameter]
        public DateTime? ToDate { get; set; }
    }
}
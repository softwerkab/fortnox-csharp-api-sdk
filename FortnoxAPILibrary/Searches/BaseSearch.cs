using System;

namespace FortnoxAPILibrary
{
    public class BaseSearch
    {
        public DateTime? LastModified { get; set; }
        public long? FinancialYearID { get; set; }
        public DateTime? FinancialYearDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
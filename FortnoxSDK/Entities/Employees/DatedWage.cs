using System;

namespace Fortnox.SDK.Entities
{
    public class DatedWage
    {
        public string EmployeeId { get; set; }
        public DateTime? FirstDay { get; set; }
        public decimal? MonthlySalary { get; set; }
        public decimal? HourlyPay { get; set; }
    }
}
using System;

namespace Fortnox.SDK.Entities;

public class DatedSchedule
{
    public string EmployeeId { get; set; }
    public DateTime? FirstDay { get; set; }
    public string ScheduleId { get; set; }
}
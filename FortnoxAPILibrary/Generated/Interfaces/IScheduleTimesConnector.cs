using System;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IScheduleTimesConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.ScheduleTimes? SortBy { get; set; }
		Filter.ScheduleTimes? FilterBy { get; set; }


		ScheduleTimes Update(ScheduleTimes scheduleTimes);
        ScheduleTimes Get(string employeeId, DateTime? date);
        ScheduleTimes Reset(string employeeId, DateTime? date);
    }
}

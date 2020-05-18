using System;
using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

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

		Task<ScheduleTimes> UpdateAsync(ScheduleTimes scheduleTimes);
        Task<ScheduleTimes> GetAsync(string employeeId, DateTime? date);
    }
}

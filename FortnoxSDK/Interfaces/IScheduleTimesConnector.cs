using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IScheduleTimesConnector : IEntityConnector
	{


		ScheduleTimes Update(ScheduleTimes scheduleTimes);
        ScheduleTimes Get(string employeeId, DateTime? date);
        ScheduleTimes Reset(string employeeId, DateTime? date);

		Task<ScheduleTimes> UpdateAsync(ScheduleTimes scheduleTimes);
        Task<ScheduleTimes> GetAsync(string employeeId, DateTime? date);
    }
}

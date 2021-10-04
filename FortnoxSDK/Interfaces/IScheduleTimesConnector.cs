using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IScheduleTimesConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        ScheduleTimes Update(ScheduleTimes scheduleTimes);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        ScheduleTimes Get(string employeeId, DateTime? date);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        ScheduleTimes Reset(string employeeId, DateTime? date);

		Task<ScheduleTimes> UpdateAsync(ScheduleTimes scheduleTimes);
        Task<ScheduleTimes> GetAsync(string employeeId, DateTime? date);
        Task<ScheduleTimes> ResetAsync(string employeeId, DateTime? date);
    }
}

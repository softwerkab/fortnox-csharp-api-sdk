using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IScheduleTimesConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    ScheduleTimes Update(ScheduleTimes scheduleTimes);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    ScheduleTimes Get(string employeeId, DateTime? date);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    ScheduleTimes Reset(string employeeId, DateTime? date);

    Task<ScheduleTimes> UpdateAsync(ScheduleTimes scheduleTimes);
    Task<ScheduleTimes> GetAsync(string employeeId, DateTime? date);
    Task<ScheduleTimes> ResetAsync(string employeeId, DateTime? date);
}
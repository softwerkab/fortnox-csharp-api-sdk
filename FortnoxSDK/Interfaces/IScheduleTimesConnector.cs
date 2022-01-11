using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IScheduleTimesConnector : IEntityConnector
{
    Task<ScheduleTimes> UpdateAsync(ScheduleTimes scheduleTimes);
    Task<ScheduleTimes> GetAsync(string employeeId, DateTime? date);
    Task<ScheduleTimes> ResetAsync(string employeeId, DateTime? date);
}
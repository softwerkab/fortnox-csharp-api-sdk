using System;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class ScheduleTimesConnector : SearchableEntityConnector<ScheduleTimes, ScheduleTimes, ScheduleTimesSearch>, IScheduleTimesConnector
{
    public ScheduleTimesConnector()
    {
        Endpoint = Endpoints.ScheduleTimes;
    }

    public EntityCollection<ScheduleTimes> Find(ScheduleTimesSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public ScheduleTimes Get(string employeeId, DateTime? date)
    {
        return GetAsync(employeeId, date).GetResult();
    }

    public ScheduleTimes Update(ScheduleTimes scheduleTime)
    {
        return UpdateAsync(scheduleTime).GetResult();
    }

    public ScheduleTimes Reset(string employeeId, DateTime? date)
    {
        return ResetAsync(employeeId, date).GetResult();
    }

    public async Task<ScheduleTimes> ResetAsync(string employeeId, DateTime? date)
    {
        return await BaseUpdate(null, employeeId, date?.ToString(ApiConstants.DateFormat), "resetday").ConfigureAwait(false);
    }

    public async Task<ScheduleTimes> UpdateAsync(ScheduleTimes scheduleTime)
    {
        return await BaseUpdate(scheduleTime, scheduleTime.EmployeeId, scheduleTime.Date?.ToString(ApiConstants.DateFormat)).ConfigureAwait(false);
    }

    public async Task<ScheduleTimes> GetAsync(string employeeId, DateTime? date)
    {
        return await BaseGet(employeeId, date?.ToString(ApiConstants.DateFormat)).ConfigureAwait(false);
    }

    public async Task<EntityCollection<ScheduleTimes>> FindAsync(ScheduleTimesSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }
}
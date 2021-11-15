using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class LockedPeriodConnector : EntityConnector<LockedPeriod>, ILockedPeriodConnector
{
    public LockedPeriodConnector()
    {
        Resource = Endpoints.LockedPeriods;
    }

    public LockedPeriod Get()
    {
        return GetAsync().GetResult();
    }

    public async Task<LockedPeriod> GetAsync()
    {
        return await BaseGet().ConfigureAwait(false);
    }
}
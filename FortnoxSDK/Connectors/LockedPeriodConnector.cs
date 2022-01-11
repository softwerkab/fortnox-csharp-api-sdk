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
        Endpoint = Endpoints.LockedPeriods;
    }

    public async Task<LockedPeriod> GetAsync()
    {
        return await BaseGet().ConfigureAwait(false);
    }
}
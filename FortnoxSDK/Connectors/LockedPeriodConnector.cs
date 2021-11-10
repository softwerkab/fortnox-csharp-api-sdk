using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors;

/// <remarks/>
internal class LockedPeriodConnector : EntityConnector<LockedPeriod>, ILockedPeriodConnector
{


    /// <remarks/>
    public LockedPeriodConnector()
    {
        Resource = "settings/lockedperiod";
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
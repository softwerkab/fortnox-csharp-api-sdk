using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class CompanySettingsConnector : EntityConnector<CompanySettings>, ICompanySettingsConnector
{
    public CompanySettingsConnector()
    {
        Endpoint = Endpoints.CompanySettings;
    }

    public CompanySettings Get()
    {
        return GetAsync().GetResult();
    }

    public async Task<CompanySettings> GetAsync()
    {
        return await BaseGet().ConfigureAwait(false);
    }
}
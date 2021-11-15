using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class CompanyInformationConnector : EntityConnector<CompanyInformation>, ICompanyInformationConnector
{
    public CompanyInformationConnector()
    {
        Resource = Endpoints.CompanyInformation;
    }

    public CompanyInformation Get()
    {
        return GetAsync().GetResult();
    }

    public async Task<CompanyInformation> GetAsync()
    {
        return await BaseGet().ConfigureAwait(false);
    }
}
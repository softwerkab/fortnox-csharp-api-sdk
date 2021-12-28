using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;

namespace Fortnox.SDK.Connectors;

internal class ProfileConnector : EntityConnector<Profile>, IProfileConnector
{
    public ProfileConnector()
    {
        Endpoint = Endpoints.Profile;
    }

    public async Task<Profile> GetAsync()
    {
        return await BaseGet().ConfigureAwait(false);
    }
}

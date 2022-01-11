using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class AccountConnector : SearchableEntityConnector<Account, AccountSubset, AccountSearch>, IAccountConnector
{
    public AccountConnector()
    {
        Endpoint = Endpoints.Accounts;
    }

    public async Task<EntityCollection<AccountSubset>> FindAsync(AccountSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id, long? finYearID = null)
    {
        var request = new BaseRequest()
        {
            Endpoint = Endpoint,
            Indices = new List<string>() { id.ToString() },
            Method = HttpMethod.Delete
        };

        if (finYearID != null)
            request.Parameters.Add("financialyear", finYearID.ToString());

        await SendAsync(request).ConfigureAwait(false);
    }

    public async Task<Account> CreateAsync(Account account, long? finYearID = null)
    {
        var request = new EntityRequest<Account>()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Post,
            Entity = account
        };

        if (finYearID != null)
            request.Parameters.Add("financialyear", finYearID.ToString());

        return await SendAsync(request).ConfigureAwait(false);
    }

    public async Task<Account> UpdateAsync(Account account, long? finYearID = null)
    {
        var request = new EntityRequest<Account>()
        {
            Endpoint = Endpoint,
            Indices = new List<string>() { account.Number.ToString() },
            Method = HttpMethod.Put,
            Entity = account
        };

        if (finYearID != null)
            request.Parameters.Add("financialyear", finYearID.ToString());

        return await SendAsync(request).ConfigureAwait(false);
    }

    public async Task<Account> GetAsync(long? id, long? finYearID = null)
    {
        //return await BaseGet(id.ToString()).ConfigureAwait(false);
        var request = new EntityRequest<Account>()
        {
            Endpoint = Endpoint,
            Indices = new List<string>() { id.ToString() },
            Method = HttpMethod.Get,
        };
        if (finYearID != null)
            request.Parameters.Add("financialyear", finYearID.ToString());

        return await SendAsync(request).ConfigureAwait(false);
    }
}
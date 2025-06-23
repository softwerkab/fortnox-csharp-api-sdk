using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;

namespace Fortnox.SDK.Connectors;

internal class StockBalanceConnector : EntityConnector<StockBalance>, IStockBalanceConnector
{
    public StockBalanceConnector()
    {
        Endpoint = Endpoints.StockBalance;
    }

    public Task<IList<StockBalance>> QueryAsync(string[] itemIds = null, string[] stockPointCodes = null)
    {
        var queryParameters = new Dictionary<string, string>();
        
        if (itemIds is { Length: > 0 })
            queryParameters.Add("itemIds", string.Join(",", itemIds));

        if (stockPointCodes is { Length: > 0 })
            queryParameters.Add("stockPointCodes", string.Join(",", stockPointCodes));
        
        return BaseQuery(queryParameters);
    }
}
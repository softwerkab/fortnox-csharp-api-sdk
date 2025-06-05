using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class StockPointConnector : EntityConnector<StockPoint>, IStockPointConnector
{
    public StockPointConnector()
    {
        Endpoint = Endpoints.StockPoints;
    }

    public Task<IList<StockPoint>> QueryAsync(string codeOrName = null, StockPointState state = StockPointState.All)
    {
        var queryParameters = new Dictionary<string, string>
        {
            ["state"] = state.GetStringValue()
        };
        if (codeOrName != null)
            queryParameters.Add("q", codeOrName);
        return BaseQuery(queryParameters);
    }

    public Task<StockPoint> GetAsync(string id)
    {
        return BaseGet(id);
    }

    public Task<StockPoint> UpdateAsync(StockPoint stockPoint)
    {
        return BaseUpdate(stockPoint, stockPoint.Id);
    }
    
    public Task<StockPoint> CreateAsync(StockPoint stockPoint)
    {
        return BaseCreate(stockPoint);
    }

    public Task DeleteAsync(string id)
    {
        return BaseDelete(id);
    }
}
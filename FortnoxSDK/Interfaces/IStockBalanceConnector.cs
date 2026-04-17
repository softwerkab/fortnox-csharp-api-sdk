using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;

namespace Fortnox.SDK.Interfaces;

/// <remarks />
public interface IStockBalanceConnector : IEntityConnector
{
    Task<IList<StockBalance>> QueryAsync(string[] itemIds = null, string[] stockPointCodes = null, Dictionary<string, string> queryParameters = null);
}
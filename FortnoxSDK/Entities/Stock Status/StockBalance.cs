using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "StockBalance", PluralName = "StockBalances")]
public class StockBalance
{
    [JsonProperty]
    [ReadOnly]
    public decimal AvailableStock { private set; get; }
    
    [JsonProperty]
    [ReadOnly]
    public decimal InStock { private set; get; }
    
    [JsonProperty]
    [ReadOnly]
    public string ItemId { private set; get; }
    
    [JsonProperty]
    [ReadOnly]
    public string StockPointCode { private set; get; }
}
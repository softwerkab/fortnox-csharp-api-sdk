using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "StockLocation", PluralName = "StockLocations")]
public class StockLocation
{
    /// <remarks/>
    [JsonProperty]
    public string Code { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string Id { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string Name { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string StockPointId { get; set; }
}
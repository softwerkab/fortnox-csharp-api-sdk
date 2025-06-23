using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "StockLocation", PluralName = "StockLocations")]
public class StockLocation
{
    /// <remarks/>
    [JsonProperty("code")]
    public string Code { get; set; }
    
    /// <remarks/>
    [JsonProperty("id")]
    public string Id { get; set; }
    
    /// <remarks/>
    [JsonProperty("name")]
    public string Name { get; set; }
    
    /// <remarks/>
    [JsonProperty("stockPointId")]
    public string StockPointId { get; set; }
}
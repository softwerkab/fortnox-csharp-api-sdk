using System.Collections.Generic;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "StockPoint", PluralName = "StockPoints")]
public class StockPoint
{
    /// <remarks/>
    [JsonProperty]
    public bool Active { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string Code { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string DeliveryAddress { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string DeliveryAddress2 { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string DeliveryCity { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string DeliveryName { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string DeliveryPhone { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string DeliveryZipCode { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string Id { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public string Name { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public IList<StockLocation> StockLocations { get; set; }
    
    /// <remarks/>
    [JsonProperty]
    public bool UsingCompanyAddress { get; set; }
}
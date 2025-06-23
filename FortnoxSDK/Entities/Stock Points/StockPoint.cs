using System.Collections.Generic;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "StockPoint", PluralName = "StockPoints")]
public class StockPoint
{
    /// <remarks/>
    [JsonProperty("active")]
    public bool Active { get; set; }
    
    /// <remarks/>
    [JsonProperty("code")]
    public string Code { get; set; }
    
    /// <remarks/>
    [JsonProperty("deliveryAddress")]
    public string DeliveryAddress { get; set; }
    
    /// <remarks/>
    [JsonProperty("deliveryAddress2")]
    public string DeliveryAddress2 { get; set; }
    
    /// <remarks/>
    [JsonProperty("deliveryCity")]
    public string DeliveryCity { get; set; }
    
    /// <remarks/>
    [JsonProperty("deliveryName")]
    public string DeliveryName { get; set; }
    
    /// <remarks/>
    [JsonProperty("deliveryPhone")]
    public string DeliveryPhone { get; set; }
    
    /// <remarks/>
    [JsonProperty("deliveryZipCode")]
    public string DeliveryZipCode { get; set; }
    
    /// <remarks/>
    [JsonProperty("id")]
    public string Id { get; set; }
    
    /// <remarks/>
    [JsonProperty("name")]
    public string Name { get; set; }
    
    /// <remarks/>
    [JsonProperty("stockLocations")]
    public IList<StockLocation> StockLocations { get; set; }
    
    /// <remarks/>
    [JsonProperty("usingCompanyAddress")]
    public bool UsingCompanyAddress { get; set; }
}
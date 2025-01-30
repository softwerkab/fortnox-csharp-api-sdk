using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities;

/// <remarks/>
[Entity(SingularName = "Customer", PluralName = "Customers")]
public class CustomerSubset
{
    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    /// <remarks/>
    [JsonProperty]
    public string Address1 { get; set; }

    /// <remarks/>
    [JsonProperty]
    public string Address2 { get; set; }

    /// <remarks/>
    [JsonProperty]
    public string City { get; set; }

    /// <remarks/>
    [JsonProperty]
    public string CustomerNumber { get; set; }

    /// <remarks/>
    [JsonProperty]
    public string Email { get; set; }

    /// <remarks/>
    [JsonProperty]
    public string Name { get; set; }

    /// <remarks/>
    [JsonProperty]
    public string OrganisationNumber { get; set; }

    /// <remarks/>
    [JsonProperty]
    public string Phone { get; set; }

    /// <remarks/>
    [JsonProperty]
    public string ZipCode { get; set; }
}
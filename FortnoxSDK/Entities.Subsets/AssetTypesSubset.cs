using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities;

/// <remarks/>
[Entity(SingularName = "Type", PluralName = "Types")]
public class AssetTypesSubset
{
    ///<summary> Direct URL to the record </summary>
    [JsonProperty("@url")]
    public Uri Url { get; set; }

    ///<summary> Number of an asset type </summary>
    [JsonProperty]
    public string Number { get; set; }

    ///<summary> Id of asset type </summary>
    [JsonProperty]
    public long? Id { get; set; }

    ///<summary> Description of the asset type </summary>
    [JsonProperty]
    public string Description { get; set; }

    ///<summary> Deprication type of asset type </summary>
    [JsonProperty]
    public string Type { get; set; }

    ///<summary> If used by any asset </summary>
    [ReadOnly]
    [JsonProperty]
    public bool? InUse { get; set; }

    ///<summary> Notes </summary>
    [JsonProperty]
    public string Notes { get; set; }
}
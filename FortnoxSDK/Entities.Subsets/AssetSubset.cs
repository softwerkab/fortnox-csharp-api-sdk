using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities;

/// <remarks/>
[Entity(SingularName = "Asset", PluralName = "Assets")]
public class AssetSubset
{
    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> AcquisitionDate</summary> 
    [JsonProperty]
    public DateTime? AcquisitionDate { get; set; }

    ///<summary> Acquisition value </summary>
    [JsonProperty]
    public decimal? AcquisitionValue { get; set; }

    ///<summary> Asset depreciated until that date or null if no deprecations made </summary>
    [ReadOnly]
    [JsonProperty]
    public DateTime? DepreciatedTo { get; private set; }

    ///<summary> Final date when asset became fully depreciated </summary>
    [JsonProperty]
    public DateTime? DepreciationFinal { get; set; }

    ///<summary> Description of asset </summary>
    [JsonProperty]
    public string Description { get; set; }

    ///<summary> Id of the asset </summary>
    [JsonProperty]
    public long? Id { get; set; }

    ///<summary> Number </summary> 
    [JsonProperty]
    public string Number { get; set; }

    ///<summary> Current status of asset </summary>
    [ReadOnly]
    [JsonProperty]
    public string Status { get; private set; }

    ///<summary> Current status id of asset. </summary>
    [ReadOnly]
    [JsonProperty]
    public string StatusId { get; private set; }

    ///<summary> Type of asset </summary>
    [ReadOnly]
    [JsonProperty]
    public string Type { get; private set; }

    ///<summary> Id of asset type used for asset </summary>
    [JsonProperty]
    public long? TypeId { get; set; }

}
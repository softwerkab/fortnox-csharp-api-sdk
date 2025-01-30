using Fortnox.SDK.Serialization;
using Newtonsoft.Json;
using System;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "Asset", PluralName = "Assets")]
public class Asset
{
    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> Id of the asset </summary>
    [ReadOnly]
    [JsonProperty]
    public long? Id { get; private set; }

    ///<summary> Description of asset </summary>
    [JsonProperty]
    public string Description { get; set; }

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

    ///<summary> Cost center Id used for asset </summary>
    [JsonProperty]
    public string CostCenter { get; set; }

    ///<summary> Project Id used for asset </summary>
    [JsonProperty]
    public string Project { get; set; }

    ///<summary> Acquisition value </summary>
    [JsonProperty]
    public decimal? AcquisitionValue { get; set; }

    ///<summary> AcquisitionDate</summary> 
    [JsonProperty]
    public DateTime? AcquisitionDate { get; set; }

    ///<summary> Number </summary> 
    [JsonProperty]
    public string Number { get; set; }

    ///<summary> Depreciations start date </summary>
    [JsonProperty]
    public DateTime? AcquisitionStart { get; set; }

    ///<summary> Final date when asset became fully depreciated </summary>
    [JsonProperty]
    public DateTime? DepreciationFinal { get; set; }

    ///<summary> Asset depreciated until that date or null if no deprecations made </summary>
    [ReadOnly]
    [JsonProperty]
    public DateTime? DepreciatedTo { get; private set; }

    ///<summary> Depreciation method </summary>
    [JsonProperty]
    public string DepreciationMethod { get; set; }

    ///<summary> Depreciate to residual value </summary>
    [JsonProperty]
    public decimal? DepreciateToResidualValue { get; set; }

    ///<summary> Manual Ob value </summary>
    [ReadOnly]
    [JsonProperty]
    public decimal? ManualOb { get; private set; }

    ///<summary> Notes </summary>
    [JsonProperty]
    public string Notes { get; set; }

    ///<summary> Reference </summary>
    [JsonProperty]
    public string Reference { get; set; }

    ///<summary> Insure number </summary>
    [JsonProperty]
    public string InsuredNumber { get; set; }

    ///<summary> Insured with </summary>
    [JsonProperty]
    public string InsuredWith { get; set; }

    ///<summary> Group </summary>
    [JsonProperty]
    public string Group { get; set; }

    ///<summary> Room </summary>
    [JsonProperty]
    public string Room { get; set; }

    ///<summary> Placement </summary>
    [JsonProperty]
    public string Placement { get; set; }

    ///<summary> Department </summary>
    [JsonProperty]
    public string Department { get; set; }
}
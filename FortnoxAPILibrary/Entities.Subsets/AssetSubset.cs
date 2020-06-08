using System;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Asset", PluralName = "Assets")]
    public class AssetSubset
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Id of the asset </summary>
        [JsonProperty]
        public string Id { get; set; }

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
        public string TypeId { get; set; }
        
        ///<summary> Acquisition value </summary>
        [JsonProperty]
        public decimal? AcquisitionValue { get; set; }

        ///<summary> AcquisitionDate</summary> 
        [JsonProperty]
        public DateTime? AcquisitionDate { get; set; }

        ///<summary> Final date when asset became fully depreciated </summary>
        [JsonProperty]
        public DateTime? DepreciationFinal { get; set; }

        ///<summary> Asset depreciated until that date or null if no deprecations made </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? DepreciatedTo { get; private set; }
    }
}

using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Type", PluralName = "Types")]
    public class AssetTypesSubset
    {
        ///<summary> Direct URL to the record </summary>
        [JsonProperty("@url")]
        public string Url { get; set; }

        ///<summary> Number of an asset type </summary>
        [JsonProperty]
        public string Number { get; set; }

        ///<summary> Id of asset type </summary>
        [JsonProperty]
        public int? Id { get; set; }

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
}

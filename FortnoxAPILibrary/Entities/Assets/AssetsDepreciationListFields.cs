using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "AssetsDepreciationListFields", PluralName = "AssetsDepreciationListFields")]
    public class AssetsDepreciationListFields
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty]
        public string URL { get; private set; }

        ///<summary> Accounted value of an asset </summary>
        [ReadOnly]
        [JsonProperty]
        public int? AccountedValue { get; private set; }

        ///<summary> Depreciation amount of an asset </summary>
        [ReadOnly]
        [JsonProperty]
        public int? DepreciationAmount { get; private set; }

        ///<summary> Depreciation period of an asset </summary>
        [ReadOnly]
        [JsonProperty]
        public string DepreciationPeriod { get; private set; }
    }
}
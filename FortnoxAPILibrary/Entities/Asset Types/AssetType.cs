using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "AssetType", PluralName = "AssetTypes")]
    public class AssetType
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Number of an asset type </summary>
        [JsonProperty]
        public string Number { get; set; }

        ///<summary> Id of asset type </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Id { get; private set; }

        ///<summary> Description of the asset type </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> Deprication type of asset type </summary>
        [JsonProperty]
        public string Type { get; set; }

        ///<summary> If used by any asset </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? InUse { get; private set; }

        ///<summary> Id of asset account </summary>
        [JsonProperty]
        public int? AccountAssetId { get; set; }

        ///<summary> Id of a value loss account </summary>
        [JsonProperty]
        public int? AccountValueLossId { get; set; }

        ///<summary> Id of a sale loss account </summary>
        [JsonProperty]
        public int? AccountSaleLossId { get; set; }

        ///<summary> Id of a sale win account </summary>
        [JsonProperty]
        public int? AccountSaleWinId { get; set; }

        ///<summary> Id of a revaluation account </summary>
        [JsonProperty]
        public int? AccountRevaluationId { get; set; }

        ///<summary> Id of an accumulated write-down account </summary>
        [JsonProperty]
        public int? AccountWriteDownAckId { get; set; }

        ///<summary> Id of a write-down account </summary>
        [JsonProperty]
        public int? AccountWriteDownId { get; set; }

        ///<summary> Id of a depreciation account </summary>
        [JsonProperty]
        public int? AccountDepreciationId { get; set; }

        ///<summary> Id and description of used account </summary>
        [ReadOnly]
        [JsonProperty]
        public string AccountAsset { get; private set; }

        ///<summary> Id and description of used account </summary>
        [ReadOnly]
        [JsonProperty]
        public string AccountValueLoss { get; private set; }

        ///<summary> Id and description of used account </summary>
        [ReadOnly]
        [JsonProperty]
        public string AccountSaleLoss { get; private set; }

        ///<summary> Id and description of used account </summary>
        [ReadOnly]
        [JsonProperty]
        public string AccountSaleWin { get; private set; }

        ///<summary> Id and description of used account </summary>
        [ReadOnly]
        [JsonProperty]
        public string AccountRevaluation { get; private set; }

        ///<summary> Id and description of used account </summary>
        [ReadOnly]
        [JsonProperty]
        public string AccountWriteDownAck { get; private set; }

        ///<summary> Id and description of used account </summary>
        [ReadOnly]
        [JsonProperty]
        public string AccountWriteDown { get; private set; }

        ///<summary> Id and description of used account </summary>
        [ReadOnly]
        [JsonProperty]
        public string AccountDepreciation { get; private set; }

        ///<summary> Notes </summary>
        [JsonProperty]
        public string Notes { get; set; }
    }
}
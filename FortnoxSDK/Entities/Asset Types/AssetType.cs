using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "AssetType", PluralName = "AssetTypes")]
    public class AssetType
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public Uri Url { get; private set; }

        ///<summary> Number of an asset type </summary>
        [JsonProperty]
        public string Number { get; set; }

        ///<summary> Id of asset type </summary>
        [ReadOnly]
        [JsonProperty]
        public long? Id { get; private set; }

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
        public long? AccountAssetId { get; set; }

        ///<summary> Id of a value loss account </summary>
        [JsonProperty]
        public long? AccountValueLossId { get; set; }

        ///<summary> Id of a sale loss account </summary>
        [JsonProperty]
        public long? AccountSaleLossId { get; set; }

        ///<summary> Id of a sale win account </summary>
        [JsonProperty]
        public long? AccountSaleWinId { get; set; }

        ///<summary> Id of a revaluation account </summary>
        [JsonProperty]
        public long? AccountRevaluationId { get; set; }

        ///<summary> Id of an accumulated write-down account </summary>
        [JsonProperty]
        public long? AccountWriteDownAckId { get; set; }

        ///<summary> Id of a write-down account </summary>
        [JsonProperty]
        public long? AccountWriteDownId { get; set; }

        ///<summary> Id of a depreciation account </summary>
        [JsonProperty]
        public long? AccountDepreciationId { get; set; }

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
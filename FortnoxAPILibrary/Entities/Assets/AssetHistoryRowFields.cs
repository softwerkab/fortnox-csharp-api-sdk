using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "AssetHistoryRowFields", PluralName = "AssetHistoryRowFields")]
    public class AssetHistoryRowFields
    {

        ///<summary> Id of history record </summary>
        [ReadOnly]
        [JsonProperty]
        public string Id { get; private set; }

        ///<summary> Date of event </summary>
        [ReadOnly]
        [JsonProperty]
        public string Date { get; private set; }

        ///<summary> Event type Id </summary>
        [ReadOnly]
        [JsonProperty]
        public string EventId { get; private set; }

        ///<summary> Amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Amount { get; private set; }

        ///<summary> User Id that performed that operation </summary>
        [ReadOnly]
        [JsonProperty]
        public string UserId { get; private set; }

        ///<summary> User name that performed that operation </summary>
        [ReadOnly]
        [JsonProperty]
        public string UserName { get; private set; }

        ///<summary> Notes for performed operation or event </summary>
        [ReadOnly]
        [JsonProperty]
        public string Notes { get; private set; }

        ///<summary> Reference to voucher number </summary>
        [ReadOnly]
        [JsonProperty]
        public string VoucherNumber { get; private set; }

        ///<summary> Reference to voucher series </summary>
        [ReadOnly]
        [JsonProperty]
        public string VoucherSeries { get; private set; }

        ///<summary> Reference to voucher year </summary>
        [ReadOnly]
        [JsonProperty]
        public string VoucherYear { get; private set; }

        ///<summary> Reference to supplier invoice if it exists </summary>
        [ReadOnly]
        [JsonProperty]
        public string SupplierInvoice { get; private set; }
    }
}
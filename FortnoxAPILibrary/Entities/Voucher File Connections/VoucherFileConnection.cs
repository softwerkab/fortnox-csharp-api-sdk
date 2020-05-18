using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "VoucherFileConnection", PluralName = "VoucherFileConnections")]
    public class VoucherFileConnection
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Id of the file </summary>
        [JsonProperty]
        public string FileId { get; set; }

        ///<summary> Description of the voucher </summary>
        [ReadOnly]
        [JsonProperty]
        public string VoucherDescription { get; private set; }

        ///<summary> Voucher number </summary>
        [JsonProperty]
        public string VoucherNumber { get; set; }

        ///<summary> Voucher series </summary>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        ///<summary> Voucher year </summary>
        [ReadOnly]
        [JsonProperty]
        public string VoucherYear { get; private set; }
    }
}
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "VoucherSeries", PluralName = "VoucherSeries")]
    public class VoucherSeries
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> The code of the voucher series </summary>
        [JsonProperty]
        public string Code { get; set; }

        ///<summary> Description of the voucher series </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> If manual </summary>
        [JsonProperty]
        public bool? Manual { get; set; }

        ///<summary> Next number in the series </summary>
        [ReadOnly]
        [JsonProperty]
        public int? NextVoucherNumber { get; private set; }

        ///<summary> Id of the financial year </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Year { get; private set; }
    }
}
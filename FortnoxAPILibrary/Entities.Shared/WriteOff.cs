using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "WriteOff", PluralName = "WriteOffs")]
    public class WriteOff
    {

        ///<summary> Amount of the writeoff </summary>
        [JsonProperty]
        public decimal? Amount { get; set; }

        ///<summary> Account number of the write off </summary>
        [JsonProperty]
        public int? AccountNumber { get; set; }

        ///<summary> Code of the cost center </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Currency of the payment </summary>
        [ReadOnly]
        [JsonProperty]
        public string Currency { get; private set; }

        ///<summary> Description of the write off </summary>
        [ReadOnly]
        [JsonProperty]
        public string Description { get; private set; }

        ///<summary> The transaction information </summary>
        [JsonProperty]
        public string TransactionInformation { get; set; }

        ///<summary> Project number of the write off </summary>
        [JsonProperty]
        public string Project { get; set; }
    }
}
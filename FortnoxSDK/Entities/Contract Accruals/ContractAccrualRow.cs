using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "ContractAccrualRow", PluralName = "ContractAccrualRows")]
    public class ContractAccrualRow
    {

        ///<summary> Account number </summary>
        [JsonProperty]
        public long? Account { get; set; }

        ///<summary> Code of the cost center </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Credit </summary>
        [JsonProperty]
        public decimal? Credit { get; set; }

        ///<summary> Debit </summary>
        [JsonProperty]
        public decimal? Debit { get; set; }

        ///<summary> Project number </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Transaction information </summary>
        [JsonProperty]
        public string TransactionInformation { get; set; }
    }
}
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "SupplierInvoiceAccrualRow", PluralName = "SupplierInvoiceAccrualRows")]
    public class SupplierInvoiceAccrualRow
    {

        ///<summary> Account number </summary>
        [JsonProperty]
        public long? Account { get; set; }

        ///<summary> Cost Center Code </summary>
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
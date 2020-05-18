using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "SupplierInvoiceRow", PluralName = "SupplierInvoiceRows")]
    public class SupplierInvoiceRow
    {

        ///<summary> Account number (If empty Fortnox will use settings from the article) </summary>
        [JsonProperty]
        public int? Account { get; set; }

        ///<summary> Article number </summary>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        ///<summary> Listed below </summary>
        [JsonProperty]
        public string Code { get; set; } //TODO: Convert to enum

        ///<summary> Cost center code </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Account Description </summary>
        [JsonProperty]
        public string AccountDescription { get; set; }

        ///<summary> Item Description </summary>
        [JsonProperty]
        public string ItemDescription { get; set; }

        ///<summary> Debit </summary>
        [JsonProperty]
        public decimal? Debit { get; set; }

        ///<summary> Debit currency </summary>
        [JsonProperty]
        public decimal? DebitCurrency { get; set; }

        ///<summary> Credit </summary>
        [JsonProperty]
        public decimal? Credit { get; set; }

        ///<summary> Credit currency </summary>
        [JsonProperty]
        public decimal? CreditCurrency { get; set; }

        ///<summary> Project code </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Unit price </summary>
        [JsonProperty]
        public decimal? Price { get; set; }

        ///<summary> Quantity </summary>
        [JsonProperty]
        public decimal? Quantity { get; set; }

        ///<summary> Row amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Total { get; private set; }

        ///<summary> Transaction information </summary>
        [JsonProperty]
        public string TransactionInformation { get; set; }

        ///<summary> Code of unit </summary>
        [ReadOnly]
        [JsonProperty]
        public string Unit { get; private set; }
    }
}
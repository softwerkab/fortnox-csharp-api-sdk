using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "ContractTemplateInvoiceRow", PluralName = "ContractTemplateInvoiceRows")]
    public class ContractTemplateInvoiceRow
    {

        ///<summary> Account number (If empty Fortnox will use setting on article) </summary>
        [JsonProperty]
        public int? AccountNumber { get; set; }

        ///<summary> Article number </summary>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        ///<summary> Cost center code </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Delivered quantity </summary>
        [JsonProperty]
        public decimal? DeliveredQuantity { get; set; }

        ///<summary> Description </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> Discount amount </summary>
        [JsonProperty]
        public decimal? Discount { get; set; }

        ///<summary> AMOUNT / PERCENT </summary>
        [JsonProperty]
        public DiscountType? DiscountType { get; set; }

        ///<summary> Unit price </summary>
        [JsonProperty]
        public decimal? Price { get; set; }

        ///<summary> Project code </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Code of unit </summary>
        [JsonProperty]
        public string Unit { get; set; }
    }
}
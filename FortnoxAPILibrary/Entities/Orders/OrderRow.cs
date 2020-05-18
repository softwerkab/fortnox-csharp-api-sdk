using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "OrderRow", PluralName = "OrderRows")]
    public class OrderRow
    {

        ///<summary> Account number (If empty Fortnox will use settings from the article) </summary>
        [JsonProperty]
        public int? AccountNumber { get; set; }

        ///<summary> Article number </summary>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        ///<summary> Contribution Percent </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? ContributionPercent { get; private set; }

        ///<summary> Contribution Value </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? ContributionValue { get; private set; }

        ///<summary> Cost center code </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Delivered quantity </summary>
        [JsonProperty]
        public decimal? DeliveredQuantity { get; set; }

        ///<summary> Description  (If empty Fortnox will use description from the article) </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> Discount amount </summary>
        [JsonProperty]
        public decimal? Discount { get; set; }

        ///<summary> Type of discount </summary>
        [JsonProperty]
        public DiscountType? DiscountType { get; set; }

        ///<summary> If the row is housework (If empty Fortnox will use settings from the article) </summary>
        [JsonProperty]
        public bool? HouseWork { get; set; }

        ///<summary> Hours to be reported if the quantity of the row should not be used as hours. </summary>
        [JsonProperty]
        public int? HouseWorkHoursToReport { get; set; }

        ///<summary> The type of house work </summary>
        [JsonProperty]
        public string HouseWorkType { get; set; }

        ///<summary> Ordered quantity </summary>
        [JsonProperty]
        public decimal? OrderedQuantity { get; set; }

        ///<summary> Unit price (If empty Fortnox will use the price from the customers price list) </summary>
        [JsonProperty]
        public decimal? Price { get; set; }

        ///<summary> Project code </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Total row amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Total { get; private set; }

        ///<summary> Code of unit </summary>
        [JsonProperty]
        public string Unit { get; set; }

        ///<summary> VAT percent code (If empty Fortnox will use settings from the article) </summary>
        [JsonProperty]
        public decimal? VAT { get; set; }
    }
}
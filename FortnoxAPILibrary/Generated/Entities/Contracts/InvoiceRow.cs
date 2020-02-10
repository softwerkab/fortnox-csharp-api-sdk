using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "InvoiceRow", PluralName = "InvoiceRows")]
    public class InvoiceRow
    {

        ///<summary> Account number (If empty Fortnox will use setting on article) </summary>
        [ReadOnly]
        [JsonProperty]
        public string AccountNumber { get; private set; }

        ///<summary> Article number </summary>
        [ReadOnly]
        [JsonProperty]
        public string ArticleNumber { get; private set; }

        ///<summary> Contribution Percent </summary>
        [ReadOnly]
        [JsonProperty]
        public string ContributionPercent { get; private set; }

        ///<summary> Contribution Value </summary>
        [ReadOnly]
        [JsonProperty]
        public string ContributionValue { get; private set; }

        ///<summary> Cost center code </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Delivered quantity </summary>
        [JsonProperty]
        public string DeliveredQuantity { get; set; }

        ///<summary> Description </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> Discount amount </summary>
        [JsonProperty]
        public string Discount { get; set; }

        ///<summary> AMOUNT / PERCENT </summary>
        [JsonProperty]
        public DiscountType? DiscountType { get; set; }

        ///<summary> – </summary>
        [JsonProperty]
        public bool? HouseWork { get; set; }

        ///<summary> Unit price </summary>
        [JsonProperty]
        public string Price { get; set; }

        ///<summary> Project code </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Row amount </summary>
        [ReadOnly]
        [JsonProperty]
        public string Total { get; private set; }

        ///<summary> Code of unit </summary>
        [JsonProperty]
        public string Unit { get; set; }

        ///<summary> Vat percent code </summary>
        [JsonProperty]
        public string VAT { get; set; }
    }
}
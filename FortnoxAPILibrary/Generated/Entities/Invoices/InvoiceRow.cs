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

        ///<summary> Account number. If not provided the predefined account will be used. </summary>
        [JsonProperty]
        public int? AccountNumber { get; set; }

        ///<summary> Article number. </summary>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        ///<summary> Contribution Percent. </summary>
        [ReadOnly]
        [JsonProperty]
        public double? ContributionPercent { get; private set; }

        ///<summary> Contribution Value. </summary>
        [ReadOnly]
        [JsonProperty]
        public double? ContributionValue { get; private set; }

        ///<summary> Code of the cost center for the row. The code must be of an existing cost center. </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Delivered quantity. </summary>
        [JsonProperty]
        public double? DeliveredQuantity { get; set; }

        ///<summary> Row description. </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> Discount amount. </summary>
        [JsonProperty]
        public double? Discount { get; set; }

        ///<summary> The type of discount used for the row. Can be AMOUNT or PERCENT. </summary>
        [JsonProperty]
        public DiscountType? DiscountType { get; set; }

        ///<summary> If the row is housework </summary>
        [JsonProperty]
        public bool? HouseWork { get; set; }

        ///<summary> Hours to be reported if the quantity of the row should not be used as hours.  Can only contain numeric values without decimals. </summary>
        [JsonProperty]
        public int? HouseWorkHoursToReport { get; set; }

        ///<summary> The type of house work. Can be  CONSTRUCTIONELECTRICITYGLASSMETALWORK  GROUNDDRAINAGEWORKMASONRY  PAINTINGWALLPAPERINGHVACMAJORAPPLIANCEREPAIR  MOVINGSERVICESITSERVICESCLEANINGTEXTILECLOTHINGSNOWPLOWING  GARDENINGBABYSITTINGOTHERCAREOTHERCOSTS or empty. </summary>
        [JsonProperty]
        public HouseWorkType? HouseWorkType { get; set; }

        ///<summary> Price per unit </summary>
        [JsonProperty]
        public double? Price { get; set; }

        ///<summary> Price per unit excluding VAT (regardless of value of VATIncluded flag) </summary>
        [ReadOnly]
        [JsonProperty]
        public double? PriceExcludingVAT { get; private set; }

        ///<summary> Code of the project for the row. The code must be of an existing project. </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Total amount for the row. </summary>
        [ReadOnly]
        [JsonProperty]
        public double? Total { get; private set; }

        ///<summary> Total amount for the row excluding VAT (regardless of value of VATIncluded flag) </summary>
        [ReadOnly]
        [JsonProperty]
        public double? TotalExcludingVAT { get; private set; }

        ///<summary> Code of the unit for the row. The code must be of an existing unit. </summary>
        [JsonProperty]
        public string Unit { get; set; }

        ///<summary> VAT percentage of the row. The percentage needs to be of an existing VAT percentage. </summary>
        [JsonProperty]
        public int? VAT { get; set; }
    }
}
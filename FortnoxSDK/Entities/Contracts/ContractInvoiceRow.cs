using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "ContractInvoiceRow", PluralName = "ContractInvoiceRows")]
public class ContractInvoiceRow
{

    ///<summary> Account number (If empty Fortnox will use setting on article) </summary>
    [JsonProperty]
    public long? AccountNumber { get; set; }

    ///<summary> Article number </summary>
    [JsonProperty]
    public string ArticleNumber { get; set; }

    ///<summary> Contribution Percent </summary>
    [ReadOnly]
    [JsonProperty]
    public decimal ContributionPercent { get; private set; }

    ///<summary> Contribution Value </summary>
    [ReadOnly]
    [JsonProperty]
    public decimal ContributionValue { get; private set; }

    ///<summary> Cost center code </summary>
    [JsonProperty]
    public string CostCenter { get; set; }

    ///<summary> Delivered quantity </summary>
    [JsonProperty]
    public decimal DeliveredQuantity { get; set; }

    ///<summary> Description </summary>
    [JsonProperty]
    public string Description { get; set; }

    ///<summary> Discount amount </summary>
    [JsonProperty]
    public decimal Discount { get; set; }

    ///<summary> AMOUNT / PERCENT </summary>
    [JsonProperty]
    public DiscountType? DiscountType { get; set; }

    ///<summary> – </summary>
    [JsonProperty]
    public bool? HouseWork { get; set; }

    ///<summary> Housework hours </summary>
    [JsonProperty]
    public int? HouseWorkHoursToReport { get; set; }

    ///<summary> Housework type </summary>
    [JsonProperty]
    public HouseworkType? HouseWorkType { get; set; }

    ///<summary> Unit price </summary>
    [JsonProperty]
    public decimal Price { get; set; }

    ///<summary> Project code </summary>
    [JsonProperty]
    public string Project { get; set; }

    ///<summary> Row amount </summary>
    [ReadOnly]
    [JsonProperty]
    public decimal Total { get; private set; }

    ///<summary> Row amount, excluding VAT </summary>
    [ReadOnly]
    [JsonProperty]
    public decimal TotalExcludingVAT { get; private set; }

    ///<summary> Code of unit </summary>
    [JsonProperty]
    public string Unit { get; set; }

    ///<summary> Vat percent code </summary>
    [JsonProperty]
    public decimal VAT { get; set; }

    /// <summary> Used for updating specific row. If not specified, the row will be handled as a new one. </summary>
    /// <remarks> See https://developer.fortnox.se/blog/updating-document-rows-using-rowid/ </remarks>
    [JsonProperty]
    public long? RowId { get; set; }
}
using System;
using System.Collections.Generic;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "TaxReduction", PluralName = "TaxReductions")]
public class TaxReduction
{
    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> Apporoved amount </summary>
    [ReadOnly]
    [JsonProperty]
    public decimal? ApprovedAmount { get; private set; }

    ///<summary> Asked amount </summary>
    [JsonProperty]
    public decimal? AskedAmount { get; set; }

    ///<summary> Billed amount </summary>
    [ReadOnly]
    [JsonProperty]
    public decimal? BilledAmount { get; private set; }

    ///<summary> Name of the customer </summary>
    [JsonProperty]
    public string CustomerName { get; set; }

    ///<summary> Id </summary>
    [ReadOnly]
    [JsonProperty]
    public string Id { get; private set; }

    ///<summary> Property designation </summary>
    [JsonProperty]
    public string PropertyDesignation { get; set; }

    ///<summary> Document type </summary>
    [JsonProperty]
    public ReferenceDocumentType? ReferenceDocumentType { get; set; }

    ///<summary> Reference number </summary>
    [JsonProperty]
    public long? ReferenceNumber { get; set; }

    ///<summary> Is request sent </summary>
    [ReadOnly]
    [JsonProperty]
    public bool? RequestSent { get; private set; }

    ///<summary> – </summary>
    [JsonProperty]
    public string ResidenceAssociationOrganisationNumber { get; set; }

    ///<summary> Social security number </summary>
    [JsonProperty]
    public string SocialSecurityNumber { get; set; }

    ///<summary> Type of reduction </summary>
    [Obsolete("Use TaxReductionType property on invoice instead. This property will be removed by Fortnox API in Q2 2021")]
    [JsonProperty]
    public TypeOfReduction? TypeOfReduction { get; set; }

    ///<summary> Voucher number </summary>
    [ReadOnly]
    [JsonProperty]
    public string VoucherNumber { get; private set; }

    ///<summary> Voucher series </summary>
    [ReadOnly]
    [JsonProperty]
    public string VoucherSeries { get; private set; }

    ///<summary> Voucher year </summary>
    [ReadOnly]
    [JsonProperty]
    public string VoucherYear { get; private set; }

    ///<summary> List of tax reduction amounts </summary>
    [JsonProperty]
    public IList<TaxReductionAmount> TaxReductionAmounts { get; set; }
}
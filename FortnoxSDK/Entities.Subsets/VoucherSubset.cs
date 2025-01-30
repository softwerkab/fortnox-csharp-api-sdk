using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities;

/// <remarks/>
[Entity(SingularName = "Voucher", PluralName = "Vouchers")]
public class VoucherSubset
{
    ///<summary> Direct URL to the record. </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> Approval state. </summary>
    [JsonProperty]
    public long? ApprovalState { get; set; }

    ///<summary> Comments. </summary>
    [JsonProperty]
    public string Comments { get; set; }

    ///<summary> Description of the voucher. </summary>
    [JsonProperty]
    public string Description { get; set; }

    ///<summary> Reference number, for example an invoice number. </summary>
    [ReadOnly]
    [JsonProperty]
    public string ReferenceNumber { get; private set; }

    ///<summary> Reference type. Can be INVOICE SUPPLIERINVOICE INVOICEPAYMENT SUPPLIERPAYMENT MANUAL CASHINVOICE or ACCRUAL </summary>
    [ReadOnly]
    [JsonProperty]
    public ReferenceType? ReferenceType { get; private set; }

    ///<summary> Date of the transaction. Must be a valid date according to our date format. </summary>
    [JsonProperty]
    public DateTime? TransactionDate { get; set; }

    ///<summary> Number of the voucher </summary>
    [ReadOnly]
    [JsonProperty]
    public long? VoucherNumber { get; private set; }

    ///<summary> Code of the voucher series. The code must be of an existing voucher series. </summary>
    [JsonProperty]
    public string VoucherSeries { get; set; }

    ///<summary> Id of the year of the voucher. </summary>
    [ReadOnly]
    [JsonProperty]
    public long? Year { get; private set; }
}
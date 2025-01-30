using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities;

/// <remarks/>
[Entity(SingularName = "SupplierInvoicePayment", PluralName = "SupplierInvoicePayments")]
public class SupplierInvoicePaymentSubset
{
    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> Amount of the payment </summary>
    [JsonProperty]
    public decimal? Amount { get; set; }

    ///<summary> If the payment is booked or not </summary>
    [ReadOnly]
    [JsonProperty]
    public bool? Booked { get; private set; }

    ///<summary> Currency of the payment </summary>
    [ReadOnly]
    [JsonProperty]
    public string Currency { get; private set; }

    ///<summary> The currency rate </summary>
    [JsonProperty]
    public decimal? CurrencyRate { get; set; }

    ///<summary> The currency unit </summary>
    [ReadOnly]
    [JsonProperty]
    public decimal? CurrencyUnit { get; private set; }

    ///<summary> Invoice number </summary>
    [JsonProperty]
    public long? InvoiceNumber { get; set; }

    ///<summary> Payment number </summary>
    [ReadOnly]
    [JsonProperty]
    public long? Number { get; private set; }

    ///<summary> Date of the payment </summary>
    [JsonProperty]
    public DateTime? PaymentDate { get; set; }

    ///<summary> Payment source </summary>
    [ReadOnly]
    [JsonProperty]
    public Source? Source { get; private set; }

    ///<summary> Write-off exist </summary>
    [ReadOnly]
    [JsonProperty]
    public bool? WriteOffExist { get; private set; }
}
using System;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "SupplierInvoice", PluralName = "SupplierInvoices")]
    public class SupplierInvoiceSubset
    {
        ///<summary> Direct url to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Balance of invoice </summary>
        [ReadOnly]
        [JsonProperty]
        public string Balance { get; private set; }

        ///<summary> If the invoice is bookkept </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Booked { get; private set; }

        ///<summary> If the invoice is cancelled </summary>
        [ReadOnly]
        [JsonProperty] //TODO: Check if "Cancelled" or "Cancel"
        public bool? Cancelled { get; private set; }

        ///<summary> Cost Center </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> If invoice is a Credit invoice (to post a credit invoice, use negative delivery quantity) </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Credit { get; private set; }

        ///<summary> Currency </summary>
        [JsonProperty]
        public string Currency { get; set; }

        ///<summary> Currency rate </summary>
        [JsonProperty]
        public decimal? CurrencyRate { get; set; }

        ///<summary> Currency unit </summary>
        [JsonProperty]
        public decimal? CurrencyUnit { get; set; }

        ///<summary> Disable payment file </summary>
        [JsonProperty]
        public bool? DisablePaymentFile { get; set; }

        ///<summary> Due date (You must specify this date even if you have posted terms of payment) </summary>
        [JsonProperty]
        public DateTime? DueDate { get; set; }

        ///<summary> External invoice number </summary>
        [JsonProperty]
        public string ExternalInvoiceNumber { get; set; }

        ///<summary> External invoice series </summary>
        [JsonProperty]
        public string ExternalInvoiceSeries { get; set; }

        ///<summary> Given Number </summary>
        [JsonProperty]
        public long? GivenNumber { get; set; }

        ///<summary> Invoice date </summary>
        [JsonProperty]
        public DateTime? InvoiceDate { get; set; }

        ///<summary> Invoice Number </summary>
        [JsonProperty]
        public string InvoiceNumber { get; set; }
        
        ///<summary> Project code </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Supplier number </summary>
        [JsonProperty]
        public string SupplierNumber { get; set; }

        ///<summary> Supplier name </summary>
        [ReadOnly]
        [JsonProperty]
        public string SupplierName { get; private set; }

        ///<summary> Total amount </summary>
        [JsonProperty]
        public decimal? Total { get; set; }

        //NEW

        //[JsonProperty]
        //public List<Voucher> Vouchers { get; set; }

        [JsonProperty]
        public DateTime? FinalPayDate { get; set; }
    }
}

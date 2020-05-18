using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "SupplierInvoicePayment", PluralName = "SupplierInvoicePayments")]
    public class SupplierInvoicePayment
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Amount of the payment </summary>
        [JsonProperty]
        public decimal? Amount { get; set; }

        ///<summary> Amount in the specified currency of the payment </summary>
        [JsonProperty]
        public decimal? AmountCurrency { get; set; }

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

        ///<summary> Information about the payment </summary>
        [JsonProperty]
        public string Information { get; set; }

        ///<summary> Invoice number </summary>
        [JsonProperty]
        public int? InvoiceNumber { get; set; }

        ///<summary> Due date of the invoice </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? InvoiceDueDate { get; private set; }

        ///<summary> OCR of the invoice </summary>
        [JsonProperty]
        public string InvoiceOCR { get; set; }

        ///<summary> Name of the supplier </summary>
        [ReadOnly]
        [JsonProperty]
        public string InvoiceSupplierName { get; private set; }

        ///<summary> Number of the supplier </summary>
        [ReadOnly]
        [JsonProperty]
        public string InvoiceSupplierNumber { get; private set; }

        ///<summary> Invoice total </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? InvoiceTotal { get; private set; }

        ///<summary> Code of the mode of payment </summary>
        [JsonProperty]
        public string ModeOfPayment { get; set; }

        ///<summary> Payment number </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Number { get; private set; }

        ///<summary> Date of the payment </summary>
        [JsonProperty]
        public DateTime? PaymentDate { get; set; }

        ///<summary> Payment source </summary>
        [ReadOnly]
        [JsonProperty]
        public Source? Source { get; private set; }

        ///<summary> Number of the voucher </summary>
        [ReadOnly]
        [JsonProperty]
        public int? VoucherNumber { get; private set; }

        ///<summary> Series of the voucher </summary>
        [ReadOnly]
        [JsonProperty]
        public string VoucherSeries { get; private set; }

        ///<summary> Id of the voucher year </summary>
        [ReadOnly]
        [JsonProperty]
        public int? VoucherYear { get; private set; }

        ///<summary>  </summary>
        [JsonProperty]
        public List<WriteOff> WriteOffs { get; set; }
    }
}
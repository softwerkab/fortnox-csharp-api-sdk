using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Invoice", PluralName = "Invoices")]
    public class InvoiceSubset
    {
        ///<summary> Direct url to the record. </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Balance of the invoice. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Balance { get; private set; }

        ///<summary> If the invoice is bookkept. This value can be changed by using the action �bookkeep�. </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Booked { get; private set; }

        ///<summary> If the invoice is cancelled. This value can be changed by using the action �cancel�. </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Cancelled { get; private set; }

        ///<summary> Code of the cost center. The code must be of an existing cost center. </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Code of the currency. The code must be of an existing currency. </summary>
        [JsonProperty]
        public string Currency { get; set; }

        ///<summary> Currency rate used for the invoice. </summary>
        [JsonProperty]
        public decimal? CurrencyRate { get; set; }

        ///<summary> Currency unit used for the invoice. </summary>
        [JsonProperty]
        public decimal? CurrencyUnit { get; set; }

        ///<summary> Name of the customer. </summary>
        [JsonProperty]
        public string CustomerName { get; set; }

        ///<summary> Customer number of the customer. The customer number must be of an existing customer. </summary>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        ///<summary> The invoice number. If no document number is provided, the next number in the series will be used. </summary>
        [JsonProperty]
        public int? DocumentNumber { get; set; }

        ///<summary> Due date of the invoice. Must be a valid date according to our date format. </summary>
        [JsonProperty]
        public DateTime? DueDate { get; set; }

        ///<summary> External invoice reference 1. </summary>
        [JsonProperty]
        public string ExternalInvoiceReference1 { get; set; }

        ///<summary> External invoice reference 2. </summary>
        [JsonProperty]
        public string ExternalInvoiceReference2 { get; set; }

        ///<summary> Invoice date. Must be a valid date according to our date format. </summary>
        [JsonProperty]
        public DateTime? InvoiceDate { get; set; }

        ///<summary> The type of invoice. Can be INVOICE AGREEMENTINVOICE INTRESTINVOICE  SUMMARYINVOICE or CASHINVOICE. </summary>
        [JsonProperty]
        public InvoiceType? InvoiceType { get; set; }

        ///<summary> If the invoice is managed by NoxFinans </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? NoxFinans { get; private set; }

        ///<summary> OCR number of the invoice. </summary>
        [JsonProperty]
        public string OCR { get; set; }

        ///<summary> Code of the project. The code must be of an existing project. </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> If the document is printed or sent in any way. </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Sent { get; private set; }

        ///<summary> Code of the terms of payment. The code must be of an existing terms of payment. </summary>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        ///<summary> The total amount of the invoice. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Total { get; private set; }
        
        ///<summary> Code of the way of delivery. The code must be of an existing way of delivery. </summary>
        [JsonProperty]
        public string WayOfDelivery { get; set; }
    }
}

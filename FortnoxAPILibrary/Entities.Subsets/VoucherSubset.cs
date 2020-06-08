using System;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Voucher", PluralName = "Vouchers")]
    public class VoucherSubset
    {
        ///<summary> Direct URL to the record. </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

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
        public int? VoucherNumber { get; private set; }

        ///<summary> Code of the voucher series. The code must be of an existing voucher series. </summary>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        ///<summary> Id of the year of the voucher. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Year { get; private set; }
    }
}

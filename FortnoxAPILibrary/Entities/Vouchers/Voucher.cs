using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Voucher", PluralName = "Vouchers")]
    public class Voucher
    {

        ///<summary> Direct URL to the record. </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Comments of the voucher. </summary>
        [JsonProperty]
        public string Comments { get; set; }

        ///<summary> Code of the cost center. The code must be of an existing cost center. </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Description of the voucher. </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> Code of the project. The code must be of an existing project. </summary>
        [JsonProperty]
        public string Project { get; set; }

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

        ///<summary> The properties for the object in this array is listed in the table for “Voucher Rows”. </summary>
        [JsonProperty]
        public List<VoucherRow> VoucherRows { get; set; }

        ///<summary> Code of the voucher series. The code must be of an existing voucher series. </summary>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        ///<summary> Id of the year of the voucher. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Year { get; private set; }

        ///<summary> The approval state f the voucher.  Not for approval: 0  Not ready for approval: 1  Not approved: 2  Approved: 3 </summary>
        [ReadOnly]
        [JsonProperty]
        public int? ApprovalState { get; private set; }
    }
}
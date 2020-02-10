using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "SupplierInvoiceAccrualRow", PluralName = "SupplierInvoiceAccrualRows")]
    public class SupplierInvoiceAccrualRow
    {

        ///<summary> Account number </summary>
        [JsonProperty]
        public int? Account { get; set; }

        ///<summary> Cost Center Code </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Credit </summary>
        [JsonProperty]
        public double? Credit { get; set; }

        ///<summary> Debit </summary>
        [JsonProperty]
        public double? Debit { get; set; }

        ///<summary> Project number </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Transaction information </summary>
        [JsonProperty]
        public string TransactionInformation { get; set; }
    }
}
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "PaymentWayValuesForCashInvoices", PluralName = "PaymentWayValuesForCashInvoices")]
    public class PaymentWayValuesForCashInvoices
    {

        ///<summary> Payment Way is set to Cash payment </summary>
        [JsonProperty]
        public string CASH { get; set; }

        ///<summary> Payment Way is set to Card. </summary>
        [JsonProperty]
        public string CARD { get; set; }

        ///<summary> Payment Way is set to Direct debit </summary>
        [JsonProperty]
        public string AG { get; set; }
    }
}
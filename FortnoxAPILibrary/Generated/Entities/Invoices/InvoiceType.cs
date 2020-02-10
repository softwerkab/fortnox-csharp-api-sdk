using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum InvoiceType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "INVOICE")]
        INVOICE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "AGREEMENTINVOICE")]
        AGREEMENTINVOICE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "INTRESTINVOICE")]
        INTRESTINVOICE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "SUMMARYINVOICE")]
        SUMMARYINVOICE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "CASHINVOICE")]
        CASHINVOICE,
    }
}
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum ReferenceType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "INVOICE")]
        INVOICE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "SUPPLIERINVOICE")]
        SUPPLIERINVOICE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "INVOICEPAYMENT")]
        INVOICEPAYMENT,
        ///<summary> No property description </summary>
        [EnumMember(Value = "SUPPLIERPAYMENT")]
        SUPPLIERPAYMENT,
        ///<summary> No property description </summary>
        [EnumMember(Value = "MANUAL")]
        MANUAL,
        ///<summary> No property description </summary>
        [EnumMember(Value = "CASHINVOICE")]
        CASHINVOICE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "ACCRUAL")]
        ACCRUAL,
    }
}
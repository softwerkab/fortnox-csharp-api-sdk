using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum Period
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "MONTHLY")]
        MONTHLY,
        ///<summary> No property description </summary>
        [EnumMember(Value = "BIMONTHLY")]
        BIMONTHLY,
        ///<summary> No property description </summary>
        [EnumMember(Value = "QUARTERLY")]
        QUARTERLY,
        ///<summary> No property description </summary>
        [EnumMember(Value = "SEMIANNUALLY")]
        SEMIANNUALLY,
        ///<summary> No property description </summary>
        [EnumMember(Value = "ANNUALLY")]
        ANNUALLY,
    }
}
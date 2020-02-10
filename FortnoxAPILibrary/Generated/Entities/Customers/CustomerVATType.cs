using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum CustomerVATType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "SEVAT")]
        SEVAT,
        ///<summary> No property description </summary>
        [EnumMember(Value = "SEREVERSEDVAT")]
        SEREVERSEDVAT,
        ///<summary> No property description </summary>
        [EnumMember(Value = "EUREVERSEDVAT")]
        EUREVERSEDVAT,
        ///<summary> No property description </summary>
        [EnumMember(Value = "EUVAT")]
        EUVAT,
        ///<summary> No property description </summary>
        [EnumMember(Value = "EXPORT")]
        EXPORT,
    }
}
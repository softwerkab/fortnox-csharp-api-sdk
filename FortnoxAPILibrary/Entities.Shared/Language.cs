using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum Language{
        ///<summary> No property description </summary>
        [EnumMember(Value = "SV")]
        SV,
        ///<summary> No property description </summary>
        [EnumMember(Value = "EN")]
        EN,
    }
}
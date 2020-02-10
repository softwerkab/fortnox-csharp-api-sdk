using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum Type
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "PRIVATE")]
        PRIVATE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "COMPANY")]
        COMPANY,
    }
}
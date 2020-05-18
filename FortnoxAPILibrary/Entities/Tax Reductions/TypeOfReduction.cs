using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum TypeOfReduction
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "ROT")]
        ROT,
        ///<summary> No property description </summary>
        [EnumMember(Value = "RUT")]
        RUT,
    }
}
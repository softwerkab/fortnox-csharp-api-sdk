using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum SupplierVATType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "REVERSE")]
        REVERSE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "NORMAL")]
        NORMAL,
        ///<summary> No property description </summary>
        [EnumMember(Value = "UIF")]
        UIF,
    }
}
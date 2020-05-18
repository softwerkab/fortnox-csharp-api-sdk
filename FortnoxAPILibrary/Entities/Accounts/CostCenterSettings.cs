using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum CostCenterSettings
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "ALLOWED")]
        ALLOWED,
        ///<summary> No property description </summary>
        [EnumMember(Value = "MANDATORY")]
        MANDATORY,
        ///<summary> No property description </summary>
        [EnumMember(Value = "NOTALLOWED")]
        NOTALLOWED,
    }
}
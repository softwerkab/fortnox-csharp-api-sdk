using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum ArticleType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "STOCK")]
        STOCK,
        ///<summary> No property description </summary>
        [EnumMember(Value = "SERVICE")]
        SERVICE,
    }
}
using System;
using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities
{
    public enum CustomerType
    {
        [EnumMember(Value = "PRIVATE")]
        Private,
        [EnumMember(Value = "COMPANY")]
        Company,
        /// <summary>
        /// Only for retrieving legacy data. Do not use.
        /// </summary>
        [Obsolete]
        [EnumMember(Value = "UNDEFINED")]
        Undefined
    }
}
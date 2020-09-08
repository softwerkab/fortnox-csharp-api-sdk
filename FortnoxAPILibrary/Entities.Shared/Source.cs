using System;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum Source
    {
        [EnumMember(Value = "manual")]
        Manual,
        [EnumMember(Value = "direct")]
        Direct,
        [Obsolete]
        [EnumMember(Value = "settle")]
        Settle,
    }
}
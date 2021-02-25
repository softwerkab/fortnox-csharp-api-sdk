using System;
using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities
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
        [EnumMember(Value = "file")]
        File,
    }
}
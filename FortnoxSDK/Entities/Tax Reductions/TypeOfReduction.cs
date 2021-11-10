using System;
using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

[Obsolete]
public enum TypeOfReduction
{
    [EnumMember(Value = "ROT")]
    ROT,
    [EnumMember(Value = "RUT")]
    RUT,
}
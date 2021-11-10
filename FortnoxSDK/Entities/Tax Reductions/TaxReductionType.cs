using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum TaxReductionType
{
    [EnumMember(Value = "rot")]
    ROT,
    [EnumMember(Value = "rut")]
    RUT,
    [EnumMember(Value = "green")]
    Green,
    [EnumMember(Value = "none")]
    None,
}
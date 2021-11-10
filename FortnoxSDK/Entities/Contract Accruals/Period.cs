using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum Period
{
    [EnumMember(Value = "MONTHLY")]
    Monthly,
    [EnumMember(Value = "BIMONTHLY")]
    BiMonthly,
    [EnumMember(Value = "QUARTERLY")]
    Quaterly,
    [EnumMember(Value = "SEMIANNUALLY")]
    SemiAnnually,
    [EnumMember(Value = "ANNUALLY")]
    Annualy,
}
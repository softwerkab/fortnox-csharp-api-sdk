using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum DiscountType
{
    [EnumMember(Value = "AMOUNT")]
    Amount,
    [EnumMember(Value = "PERCENT")]
    Percent,
}
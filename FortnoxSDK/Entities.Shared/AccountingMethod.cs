using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum AccountingMethod
{
    [EnumMember(Value = "ACCRUAL")]
    Accrual,

    [EnumMember(Value = "CASH")]
    Cash,
}
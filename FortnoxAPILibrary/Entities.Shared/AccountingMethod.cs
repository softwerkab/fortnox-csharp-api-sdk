using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum AccountingMethod
    {
        [EnumMember(Value = "ACCRUAL")]
        Accrual,
        [EnumMember(Value = "CASH")]
        Cash,
    }
}
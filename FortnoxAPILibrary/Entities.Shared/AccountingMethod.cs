using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum AccountingMethod
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "ACCRUAL")]
        ACCRUAL,
        ///<summary> No property description </summary>
        [EnumMember(Value = "CASH")]
        CASH,
    }
}
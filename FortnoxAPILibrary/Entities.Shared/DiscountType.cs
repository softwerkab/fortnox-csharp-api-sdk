using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum DiscountType
    {
        [EnumMember(Value = "AMOUNT")]
        Amount,
        [EnumMember(Value = "PERCENT")]
        Percent,
    }
}
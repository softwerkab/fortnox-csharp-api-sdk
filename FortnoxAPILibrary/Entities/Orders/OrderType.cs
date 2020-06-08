using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum OrderType
    {
        [EnumMember(Value = "Order")]
        Order,
        [EnumMember(Value = "Backorder")]
        Backorder,
    }
}
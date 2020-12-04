using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities
{
    public enum OrderType
    {
        [EnumMember(Value = "Order")]
        Order,
        [EnumMember(Value = "Backorder")]
        Backorder,
    }
}
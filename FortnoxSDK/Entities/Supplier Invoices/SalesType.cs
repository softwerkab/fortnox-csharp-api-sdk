using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities
{
    public enum SalesType
    {
        [EnumMember(Value = "STOCK")]
        Stock,
        [EnumMember(Value = "SERVICE")]
        Service,
    }
}
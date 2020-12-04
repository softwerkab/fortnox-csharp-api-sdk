using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities
{
    public enum ArticleType
    {
        [EnumMember(Value = "STOCK")]
        Stock,
        [EnumMember(Value = "SERVICE")]
        Service,
    }
}
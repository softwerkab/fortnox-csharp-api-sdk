using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum ArticleType
    {
        [EnumMember(Value = "STOCK")]
        Stock,
        [EnumMember(Value = "SERVICE")]
        Service,
    }
}
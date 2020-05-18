using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum SalesType
    {
        [EnumMember(Value = "STOCK")]
        Stock,
        [EnumMember(Value = "SERVICE")]
        Service,
    }
}
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum CustomerType
    {
        [EnumMember(Value = "PRIVATE")]
        Private,
        [EnumMember(Value = "COMPANY")]
        Company,
    }
}
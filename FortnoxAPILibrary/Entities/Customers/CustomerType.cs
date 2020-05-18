using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum CustomerType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "PRIVATE")]
        PRIVATE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "COMPANY")]
        COMPANY,
    }
}
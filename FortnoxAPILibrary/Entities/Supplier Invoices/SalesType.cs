using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum SalesType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "STOCK")]
        STOCK,
        ///<summary> No property description </summary>
        [EnumMember(Value = "SERVICE")]
        SERVICE,
    }
}
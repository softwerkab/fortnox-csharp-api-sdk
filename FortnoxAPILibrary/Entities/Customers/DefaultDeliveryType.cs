using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum DefaultDeliveryType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "PRINT")]
        PRINT,
        ///<summary> No property description </summary>
        [EnumMember(Value = "EMAIL")]
        EMAIL,
        ///<summary> No property description </summary>
        [EnumMember(Value = "PRINTSERVICE")]
        PRINTSERVICE,
    }
}
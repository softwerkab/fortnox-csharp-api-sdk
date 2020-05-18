using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum ProjectSettings
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "ALLOWED")]
        ALLOWED,
        ///<summary> No property description </summary>
        [EnumMember(Value = "MANDATORY")]
        MANDATORY,
        ///<summary> No property description </summary>
        [EnumMember(Value = "NOTALLOWED")]
        NOTALLOWED,
    }
}
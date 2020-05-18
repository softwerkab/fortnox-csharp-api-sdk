using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum ProjectSettings
    {
        [EnumMember(Value = "ALLOWED")]
        Allowed,
        [EnumMember(Value = "MANDATORY")]
        Mandatory,
        [EnumMember(Value = "NOTALLOWED")]
        NotAllowed,
    }
}
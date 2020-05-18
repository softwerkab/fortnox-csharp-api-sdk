using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum CostCenterSettings
    {
        [EnumMember(Value = "ALLOWED")]
        Allowed,
        [EnumMember(Value = "MANDATORY")]
        Mandatory,
        [EnumMember(Value = "NOTALLOWED")]
        NotAllowed,
    }
}
using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum ProjectSettings
{
    [EnumMember(Value = "ALLOWED")]
    Allowed,
    [EnumMember(Value = "MANDATORY")]
    Mandatory,
    [EnumMember(Value = "NOTALLOWED")]
    NotAllowed,
}
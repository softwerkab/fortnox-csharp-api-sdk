using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities
{
    public enum Status
    {
        [EnumMember(Value = "NOTSTARTED")]
        NotStarted,
        [EnumMember(Value = "ONGOING")]
        Ongoing,
        [EnumMember(Value = "COMPLETED")]
        Completed,
    }
}
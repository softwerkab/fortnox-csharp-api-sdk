using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
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
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum Language{
        [EnumMember(Value = "SV")]
        Swedish,
        [EnumMember(Value = "EN")]
        English,
    }
}
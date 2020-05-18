using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum TypeOfReduction
    {
        [EnumMember(Value = "ROT")]
        ROT,
        [EnumMember(Value = "RUT")]
        RUT,
    }
}
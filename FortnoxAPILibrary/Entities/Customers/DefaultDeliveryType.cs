using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum DefaultDeliveryType
    { 
        [EnumMember(Value = "PRINT")]
        Print,
        [EnumMember(Value = "EMAIL")]
        Email,
        [EnumMember(Value = "PRINTSERVICE")]
        PrintService,
    }
}
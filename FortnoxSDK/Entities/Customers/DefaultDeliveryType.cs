using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities
{
    public enum DefaultDeliveryType
    {
        [EnumMember(Value = "PRINT")]
        Print,
        [EnumMember(Value = "EMAIL")]
        Email,
        [EnumMember(Value = "PRINTSERVICE")]
        PrintService,
        [EnumMember(Value = "ELECTRONICINVOICE")]
        ElectronicInvoice
    }
}
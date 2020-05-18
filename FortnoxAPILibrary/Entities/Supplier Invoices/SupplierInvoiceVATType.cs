using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum SupplierInvoiceVATType
    {
        [EnumMember(Value = "NORMAL")]
        Normal,
        [EnumMember(Value = "EUINTERNAL")]
        EUInternal,
        [EnumMember(Value = "REVERSE")]
        Reverse,
    }
}
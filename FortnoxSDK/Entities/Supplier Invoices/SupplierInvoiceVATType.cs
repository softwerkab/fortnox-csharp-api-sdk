using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum SupplierInvoiceVATType
{
    [EnumMember(Value = "NORMAL")]
    Normal,
    [EnumMember(Value = "EUINTERNAL")]
    EUInternal,
    [EnumMember(Value = "REVERSE")]
    Reverse,
}
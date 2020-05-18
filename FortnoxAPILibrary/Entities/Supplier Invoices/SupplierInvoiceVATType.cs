using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum SupplierInvoiceVATType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "NORMAL")]
        NORMAL,
        ///<summary> No property description </summary>
        [EnumMember(Value = "EUINTERNAL")]
        EUINTERNAL,
        ///<summary> No property description </summary>
        [EnumMember(Value = "REVERSE")]
        REVERSE,
    }
}
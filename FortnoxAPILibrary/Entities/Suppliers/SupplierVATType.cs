using System;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum SupplierVATType
    {
        [EnumMember(Value = "25")]
        VAT25,
        [EnumMember(Value = "12")]
        VAT12,
        [EnumMember(Value = "6")]
        VAT6,
        [EnumMember(Value = "0")]
        VAT0,
        [EnumMember(Value = "REVERSE")]
        Reverse,
        [Obsolete]
        [EnumMember(Value = "NORMAL")]
        Normal,
        /// <summary> Unionsinternt förvärv </summary>
        [EnumMember(Value = "UIF")]
        UIF
    }
}
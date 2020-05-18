using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum TaxAllowance
    {
        ///<summary> Main employer </summary>
        [EnumMember(Value = "HUV")]
        HUV,
        ///<summary> Extra income or short-time work </summary>
        [EnumMember(Value = "EXT")]
        EXT,
        ///<summary> Short-time work less than one week </summary>
        [EnumMember(Value = "TMP")]
        TMP,
        ///<summary> Student without tax deduction </summary>
        [EnumMember(Value = "STU")]
        STU,
        ///<summary> Not tax allowance </summary>
        [EnumMember(Value = "EJ")]
        EJ,
        ///<summary> Unknown tax circumstances </summary>
        [EnumMember(Value = "???")]
        Unknown,
    }
}
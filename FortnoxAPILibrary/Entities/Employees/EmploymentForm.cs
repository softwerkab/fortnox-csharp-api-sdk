using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum EmploymentForm
    {
        ///<summary> Post with conditional tenure </summary>
        [EnumMember(Value = "TV")]
        TV,
        ///<summary> Probationary appointment </summary>
        [EnumMember(Value = "PRO")]
        PRO,
        ///<summary> Temporary employment </summary>
        [EnumMember(Value = "TID")]
        TID,
        ///<summary> Cover staff </summary>
        [EnumMember(Value = "VIK")]
        VIK,
        ///<summary> Project employment </summary>
        [EnumMember(Value = "PRJ")]
        PRJ,
        ///<summary> Work experience </summary>
        [EnumMember(Value = "PRA")]
        PRA,
        ///<summary> Holiday work </summary>
        [EnumMember(Value = "FER")]
        FER,
        ///<summary> Seasonal employment </summary>
        [EnumMember(Value = "SES")]
        SES,
        ///<summary> Not employed </summary>
        [EnumMember(Value = "NEJ")]
        NEJ,
    }
}
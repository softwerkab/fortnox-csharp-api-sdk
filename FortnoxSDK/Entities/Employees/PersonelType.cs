using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum PersonelType
{
    ///<summary> Salaried employee </summary>
    [EnumMember(Value = "TJM")]
    TJM,
    ///<summary> Worker </summary>
    [EnumMember(Value = "ARB")]
    ARB,
}
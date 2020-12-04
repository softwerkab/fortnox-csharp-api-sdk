using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities
{
    public enum SalaryForm
    {
        ///<summary> Monthly salary </summary>
        [EnumMember(Value = "MAN")]
        Monthly,
        ///<summary> Hourly pay </summary>
        [EnumMember(Value = "TIM")]
        Hourly,
    }
}
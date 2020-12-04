using Fortnox.SDK.Serialization;
using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "PaymentWayValuesForCashInvoices", PluralName = "PaymentWayValuesForCashInvoices")]
    public enum PaymentWay
    {
        ///<summary> Cash payment </summary>
        [EnumMember(Value="CASH")]
        Cash,
        ///<summary> Card. </summary>
        [EnumMember(Value="CARD")]
        Card,
        ///<summary> Direct debit </summary>
        [EnumMember(Value = "AG")]
        AutoGiro
    }
}
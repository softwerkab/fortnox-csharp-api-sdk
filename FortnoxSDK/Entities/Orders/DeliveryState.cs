using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum DeliveryState
{
    [EnumMember(Value = "delivery")]
    Delivery,
    [EnumMember(Value = "registration")]
    Registration,
    [EnumMember(Value = "reservation")]
    Reservation
}

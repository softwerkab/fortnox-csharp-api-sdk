using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum TaxReductionWorkType
{
    [EnumMember(Value = "SOLARCELLS")] 
    SolarCells,

    [EnumMember(Value = "STORAGESELFPRODUCEDELECTRICITY")]
    StorageSelfProducedElectricity,

    [EnumMember(Value = "CHARGINGSTATIONELECTRICVEHICLE")]
    ChargingStationElectricVehicle
}
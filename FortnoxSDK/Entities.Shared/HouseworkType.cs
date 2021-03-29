using System;
using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities
{
    public enum HouseworkType
    {
        [EnumMember(Value = "CONSTRUCTION")]
        Construction,
        [EnumMember(Value = "ELECTRICITY")]
        Electricity,
        [EnumMember(Value = "GLASSMETALWORK")]
        GlassMetalWork,
        [EnumMember(Value = "GROUNDDRAINAGEWORK")]
        GroundDrainageWork,
        [EnumMember(Value = "MASONRY")]
        Masonry,
        [EnumMember(Value = "PAINTINGWALLPAPERING")]
        PaintingWallpapering,
        [EnumMember(Value = "HVAC")]
        HVAC,
        [EnumMember(Value = "MAJORAPPLIANCEREPAIR")]
        MajorApplianceRepair,
        [EnumMember(Value = "MOVINGSERVICES")]
        MovingServices,
        [EnumMember(Value = "ITSERVICES")]
        ITServices,
        [EnumMember(Value = "CLEANING")]
        Cleaning,
        [EnumMember(Value = "TEXTILECLOTHING")]
        TextileClothing,
        [EnumMember(Value = "SNOWPLOWING")]
        Snowplowing,
        [EnumMember(Value = "GARDENING")]
        Gardening,
        [EnumMember(Value = "BABYSITTING")]
        Babysitting,
        [EnumMember(Value = "OTHERCARE")]
        OtherCare,
        [EnumMember(Value = "OTHERCOSTS")]
        OtherCosts,

        [Obsolete]
        [EnumMember(Value = "COOKING")]
        Cooking,
        [Obsolete]
        [EnumMember(Value = "TUTORING")]
        Tutoring,

        [EnumMember(Value = "SOLARCELLS")]
        SolarCells,
        [EnumMember(Value = "STORAGESELFPRODUCEDELECTRICITY")]
        StorageSelfProducedElectricity,
        [EnumMember(Value = "CHARGINGSTATIONELECTRICVEHICLE")]
        ChargingStationElectricVehicle,
        [EnumMember(Value = "HOMEMAINTENANCE")]
        HomeMaintenance,
        [EnumMember(Value = "FURNISHING")]
        Furnishing,
        [EnumMember(Value = "TRANSPORTATIONSERVICES")]
        TransportationServices,
        [EnumMember(Value = "WASHINGANDCAREOFCLOTHING")]
        WashingAndCareOfClothing,

        /// <summary>
        /// More info about usage at https://developer.fortnox.se/blog/best-practise-new-housework-invoice/
        /// </summary>
        [EnumMember(Value = "EMPTYHOUSEWORK")]
        EmptyHousework,

        /// <summary>
        /// Use with Update request to clear existing value
        /// </summary>
        [EnumMember(Value = APIConstants.BlankValue)]
        Blank
    }
}
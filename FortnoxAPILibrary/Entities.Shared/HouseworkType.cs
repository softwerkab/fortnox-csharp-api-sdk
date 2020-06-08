using System;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
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
        [EnumMember(Value = "API_BLANK")]
        Empty,

        [Obsolete]
        [EnumMember(Value = "COOKING")]
        Cooking,
        [Obsolete]
        [EnumMember(Value = "TUTORING")]
        Tutoring,
    }
}
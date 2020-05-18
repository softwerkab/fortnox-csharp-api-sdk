using System;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum HouseworkType
    {
        [EnumMember(Value = "CONSTRUCTION")]
        CONSTRUCTION,
        [EnumMember(Value = "ELECTRICITY")]
        ELECTRICITY,
        [EnumMember(Value = "GLASSMETALWORK")]
        GLASSMETALWORK,
        [EnumMember(Value = "GROUNDDRAINAGEWORK")]
        GROUNDDRAINAGEWORK,
        [EnumMember(Value = "MASONRY")]
        MASONRY,
        [EnumMember(Value = "PAINTINGWALLPAPERING")]
        PAINTINGWALLPAPERING,
        [EnumMember(Value = "HVAC")]
        HVAC,
        [EnumMember(Value = "MAJORAPPLIANCEREPAIR")]
        MAJORAPPLIANCEREPAIR,
        [EnumMember(Value = "MOVINGSERVICES")]
        MOVINGSERVICES,
        [EnumMember(Value = "ITSERVICES")]
        SITSERVICES,
        [EnumMember(Value = "CLEANING")]
        CLEANING,
        [EnumMember(Value = "TEXTILECLOTHING")]
        TEXTILECLOTHING,
        [EnumMember(Value = "SNOWPLOWING")]
        SNOWPLOWING,
        [EnumMember(Value = "GARDENING")]
        GARDENING,
        [EnumMember(Value = "BABYSITTING")]
        BABYSITTING,
        [EnumMember(Value = "OTHERCARE")]
        OTHERCARE,
        [EnumMember(Value = "OTHERCOSTS")]
        OTHERCOSTS,
        [EnumMember(Value = "API_BLANK")]
        Empty,

        [Obsolete]
        [EnumMember(Value = "COOKING")]
        COOKING,
        [Obsolete]
        [EnumMember(Value = "TUTORING")]
        TUTORING,
    }
}
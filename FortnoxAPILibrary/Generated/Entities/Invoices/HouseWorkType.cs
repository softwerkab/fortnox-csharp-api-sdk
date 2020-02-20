using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum HouseWorkType
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
        [EnumMember(Value = "PAINTING")]
        PAINTING,
        [EnumMember(Value = "WALLPAPERING")]
        WALLPAPERING,
        [EnumMember(Value = "HVAC")]
        HVAC,
        [EnumMember(Value = "MAJORAPPLIANCEREPAIR")]
        MAJORAPPLIANCEREPAIR,
        [EnumMember(Value = "MOVINGSERVICE")]
        MOVINGSERVICE,
        [EnumMember(Value = "SITSERVICES")]
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
        [EnumMember(Value = "")]
        Empty
    }
}
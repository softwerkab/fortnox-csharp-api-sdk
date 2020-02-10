using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum HouseworkType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "CONSTRUCTION")]
        CONSTRUCTION,
        ///<summary> No property description </summary>
        [EnumMember(Value = "ELECTRICITY")]
        ELECTRICITY,
        ///<summary> No property description </summary>
        [EnumMember(Value = "GLASSMETALWORK")]
        GLASSMETALWORK,
        ///<summary> No property description </summary>
        [EnumMember(Value = "GROUNDDRAINAGEWORK")]
        GROUNDDRAINAGEWORK,
        ///<summary> No property description </summary>
        [EnumMember(Value = "MASONRY")]
        MASONRY,
        ///<summary> No property description </summary>
        [EnumMember(Value = "PAINTINGWALLPAPERING")]
        PAINTINGWALLPAPERING,
        ///<summary> No property description </summary>
        [EnumMember(Value = "HVAC")]
        HVAC,
        ///<summary> No property description </summary>
        [EnumMember(Value = "CLEANING")]
        CLEANING,
        ///<summary> No property description </summary>
        [EnumMember(Value = "TEXTILECLOTHING")]
        TEXTILECLOTHING,
        ///<summary> No property description </summary>
        [EnumMember(Value = "COOKING")]
        COOKING,
        ///<summary> No property description </summary>
        [EnumMember(Value = "SNOWPLOWING")]
        SNOWPLOWING,
        ///<summary> No property description </summary>
        [EnumMember(Value = "GARDENING")]
        GARDENING,
        ///<summary> No property description </summary>
        [EnumMember(Value = "BABYSITTING")]
        BABYSITTING,
        ///<summary> No property description </summary>
        [EnumMember(Value = "OTHERCARE")]
        OTHERCARE,
        ///<summary> No property description </summary>
        [EnumMember(Value = "TUTORING")]
        TUTORING,
        ///<summary> No property description </summary>
        [EnumMember(Value = "OTHERCOSTS")]
        OTHERCOSTS,
        ///<summary> No property description </summary>
        [EnumMember(Value = "empty")]
        empty,
    }
}
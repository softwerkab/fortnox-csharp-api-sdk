using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum HouseWorkType
    {
        ///<summary> No property description </summary>
        [EnumMember(Value = "CONSTRUCTIONELECTRICITYGLASSMETALWORK")]
        CONSTRUCTIONELECTRICITYGLASSMETALWORK,
        ///<summary> No property description </summary>
        [EnumMember(Value = "GROUNDDRAINAGEWORKMASONRY")]
        GROUNDDRAINAGEWORKMASONRY,
        ///<summary> No property description </summary>
        [EnumMember(Value = "PAINTINGWALLPAPERINGHVACMAJORAPPLIANCEREPAIR")]
        PAINTINGWALLPAPERINGHVACMAJORAPPLIANCEREPAIR,
        ///<summary> No property description </summary>
        [EnumMember(Value = "MOVINGSERVICESITSERVICESCLEANINGTEXTILECLOTHINGSNOWPLOWING")]
        MOVINGSERVICESITSERVICESCLEANINGTEXTILECLOTHINGSNOWPLOWING,
        ///<summary> No property description </summary>
        [EnumMember(Value = "GARDENINGBABYSITTINGOTHERCAREOTHERCOSTS")]
        GARDENINGBABYSITTINGOTHERCAREOTHERCOSTS,
        ///<summary> No property description </summary>
        [EnumMember(Value = "empty")]
        empty,
    }
}
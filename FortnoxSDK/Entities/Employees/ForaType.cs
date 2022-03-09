using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum ForaType
{
    ///<summary> Not signed </summary>
    [EnumMember(Value = "-")]
    None,
    ///<summary> Worker </summary>
    [EnumMember(Value = "A")]
    A,
    ///<summary> Workers, Painters </summary>
    [EnumMember(Value = "A3")]
    A3,
    ///<summary> Worker, Construction contract </summary>
    [EnumMember(Value = "A12")]
    A12,
    ///<summary> Worker, Electrician – Installation plant contract </summary>
    [EnumMember(Value = "A91")]
    A91,
    ///<summary> Worker, Electrician – Power plant contract </summary>
    [EnumMember(Value = "A92")]
    A92,
    ///<summary> Worker, Electrician – Elektroskandia contract </summary>
    [EnumMember(Value = "A93")]
    A93,
    ///<summary> Worker, Technology Agreement IF Metall </summary>
    [EnumMember(Value = "A51")]
    A51,
    ///<summary> Worker, TEKO Agreement </summary>
    [EnumMember(Value = "A52")]
    A52,
    ///<summary> Worker, Food Production Agreement </summary>
    [EnumMember(Value = "A53")]
    A53,
    ///<summary> Worker, Tobacco Industry </summary>
    [EnumMember(Value = "A54")]
    A54,
    ///<summary> Worker, Company Agreement for V&amp;S Vin &amp; Sprit AB </summary>
    [EnumMember(Value = "A55")]
    A55,
    ///<summary> Worker, Coffee Roasters and Spice Factories </summary>
    [EnumMember(Value = "A56")]
    A56,
    ///<summary> Worker, Construction Materials Industry </summary>
    [EnumMember(Value = "A57")]
    A57,
    ///<summary> Worker, Bottle Glass Industry </summary>
    [EnumMember(Value = "A58")]
    A58,
    ///<summary> Worker, Motor Industry Agreement </summary>
    [EnumMember(Value = "A59")]
    A59,
    ///<summary> Worker, Industry Agreement </summary>
    [EnumMember(Value = "A60")]
    A60,
    ///<summary> Worker, Leather &amp; Sporting Goods </summary>
    [EnumMember(Value = "A61")]
    A61,
    ///<summary> Worker, Chemical Factories </summary>
    [EnumMember(Value = "A62")]
    A62,
    ///<summary> Worker, Glass Industry </summary>
    [EnumMember(Value = "A63")]
    A63,
    ///<summary> Worker, Common Metals </summary>
    [EnumMember(Value = "A64")]
    A64,
    ///<summary> Worker, Explosive Materials Industry </summary>
    [EnumMember(Value = "A65")]
    A65,
    ///<summary> Worker, Allochemical Industry </summary>
    [EnumMember(Value = "A66")]
    A66,
    ///<summary> Worker, Recycling Company </summary>
    [EnumMember(Value = "A67")]
    A67,
    ///<summary> Worker, Laundy Industry </summary>
    [EnumMember(Value = "A68")]
    A68,
    ///<summary> Worker, Quarrying Industry </summary>
    [EnumMember(Value = "A69")]
    A69,
    ///<summary> Worker, Oil Refineries </summary>
    [EnumMember(Value = "A70")]
    A70,
    ///<summary> Worker, Sugar Industry (Nordic Sugar AB) </summary>
    [EnumMember(Value = "A71")]
    A71,
    ///<summary> Worker, IMG Agreement </summary>
    [EnumMember(Value = "A72")]
    A72,
    ///<summary> Worker, Sawmill Agreement </summary>
    [EnumMember(Value = "A73")]
    A73,
    ///<summary> Worker, Forestry Agreement </summary>
    [EnumMember(Value = "A74")]
    A74,
    ///<summary> Worker, Scaling of timber </summary>
    [EnumMember(Value = "A75")]
    A75,
    ///<summary> Worker, Upholstery Industry </summary>
    [EnumMember(Value = "A76")]
    A76,
    ///<summary> Worker, Wood Industry </summary>
    [EnumMember(Value = "A77")]
    A77,
    ///<summary> Salaried employee </summary>
    [EnumMember(Value = "T")]
    T,
    ///<summary> Salaried employee, Employed CEO </summary>
    [EnumMember(Value = "T6")]
    T6,

    [EnumMember(Value = "A78")]
    A78,
    [EnumMember(Value = "A79")]
    A79,
    [EnumMember(Value = "A80")]
    A80,
    [EnumMember(Value = "A81")]
    A81,
    [EnumMember(Value = "A82")]
    A82,
    [EnumMember(Value = "A83")]
    A83,
    [EnumMember(Value = "A84")]
    A84,
    [EnumMember(Value = "A85")]
    A85,
    [EnumMember(Value = "A86")]
    A86,
    [EnumMember(Value = "A11")]
    A11,
    [EnumMember(Value = "A13")]
    A13,
    [EnumMember(Value = "A14")]
    A14,
    [EnumMember(Value = "A15")]
    A15,
    [EnumMember(Value = "A16")]
    A16,
    [EnumMember(Value = "A17")]
    A17,
    [EnumMember(Value = "A18")]
    A18,
    [EnumMember(Value = "A19")]
    A19,
    [EnumMember(Value = "A20")]
    A20,
    [EnumMember(Value = "A21")]
    A21,
    [EnumMember(Value = "A22")]
    A22,
    [EnumMember(Value = "A23")]
    A23,
    [EnumMember(Value = "A24")]
    A24,
    [EnumMember(Value = "A25")]
    A25,
    [EnumMember(Value = "A26")]
    A26,
    [EnumMember(Value = "A27")]
    A27,
    [EnumMember(Value = "A28")]
    A28,
    [EnumMember(Value = "A29")]
    A29,
    [EnumMember(Value = "A30")]
    A30,
    [EnumMember(Value = "A41")]
    A41,
    [EnumMember(Value = "A42")]
    A42,
    [EnumMember(Value = "A43")]
    A43,
    [EnumMember(Value = "A44")]
    A44,
    [EnumMember(Value = "A45")]
    A45,
    [EnumMember(Value = "A46")]
    A46,
    [EnumMember(Value = "A47")]
    A47,
    [EnumMember(Value = "A48")]
    A48,
}
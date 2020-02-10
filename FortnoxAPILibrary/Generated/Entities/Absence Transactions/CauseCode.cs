using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum CauseCode
    {
        ///<summary> Arbetsskada </summary>
        [EnumMember(Value = "ASK")]
        ASK,
        ///<summary> Arbetstidsf�rkortning </summary>
        [EnumMember(Value = "ATF")]
        ATF,
        ///<summary> F�r�ldraledig </summary>
        [EnumMember(Value = "FPE")]
        FPE,
        ///<summary> Fr�nvaro �vrigt </summary>
        [EnumMember(Value = "FRA")]
        FRA,
        ///<summary> Fr�nvaro �vrigt (used in PAXml) </summary>
        [EnumMember(Value = "FR1")]
        FR1,
        ///<summary> Graviditetspenning </summary>
        [EnumMember(Value = "HAV")]
        HAV,
        ///<summary> Kompledig </summary>
        [EnumMember(Value = "KOM")]
        KOM,
        ///<summary> Milit�rtj�nst (max 60 dagar) </summary>
        [EnumMember(Value = "MIL")]
        MIL,
        ///<summary> N�rst�endev�rd </summary>
        [EnumMember(Value = "NAR")]
        NAR,
        /////<summary> N�rst�endev�rd (used in PAXml) </summary>
        //[EnumMember(Value = "N�R")]
        NÄR,
        ///<summary> Sjuk-OB 1 </summary>
        [EnumMember(Value = "OS1")]
        OS1,
        ///<summary> Sjuk-OB 2 </summary>
        [EnumMember(Value = "OS2")]
        OS2,
        ///<summary> Sjuk-OB 3 </summary>
        [EnumMember(Value = "OS3")]
        OS3,
        ///<summary> Sjuk-OB 4 </summary>
        [EnumMember(Value = "OS4")]
        OS4,
        ///<summary> Sjuk-OB 5 </summary>
        [EnumMember(Value = "OS5")]
        OS5,
        ///<summary> Pappadagar </summary>
        [EnumMember(Value = "PAP")]
        PAP,
        ///<summary> Permission </summary>
        [EnumMember(Value = "PEM")]
        PEM,
        ///<summary> Permitterad </summary>
        [EnumMember(Value = "PER")]
        PER,
        ///<summary> Semester </summary>
        [EnumMember(Value = "SEM")]
        SEM,
        ///<summary> Sjukfr�nvaro </summary>
        [EnumMember(Value = "SJK")]
        SJK,
        ///<summary> Smittb�rare </summary>
        [EnumMember(Value = "SMB")]
        SMB,
        ///<summary> Svenska f�r invandrare </summary>
        [EnumMember(Value = "SVE")]
        SVE,
        ///<summary> Tj�nstledig </summary>
        [EnumMember(Value = "TJL")]
        TJL,
        ///<summary> Facklig utbildning </summary>
        [EnumMember(Value = "UTB")]
        UTB,
        ///<summary> Facklig utbildning (used in PAXml) </summary>
        [EnumMember(Value = "FAC")]
        FAC,
        ///<summary> V�rd av barn </summary>
        [EnumMember(Value = "VAB")]
        VAB,
    }
}
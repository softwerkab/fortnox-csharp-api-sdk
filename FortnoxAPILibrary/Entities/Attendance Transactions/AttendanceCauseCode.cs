using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum AttendanceCauseCode
    {
        ///<summary> Timlön </summary>
        [EnumMember(Value = "ARB")]
        ARB,
        ///<summary> Beredskapstid 2 </summary>
        [EnumMember(Value = "BE2")]
        BE2,
        ///<summary> Beredskapstid </summary>
        [EnumMember(Value = "BER")]
        BER,
        ///<summary> Beredskapstid (used in PAXml) </summary>
        [EnumMember(Value = "BE1")]
        BE1,
        ///<summary> Flextid +/- </summary>
        [EnumMember(Value = "FLX")]
        FLX,
        ///<summary> HelglÖn </summary>
        [EnumMember(Value = "HLG")]
        HLG,
        ///<summary> Jourtid 2 </summary>
        [EnumMember(Value = "JO2")]
        JO2,
        ///<summary> Jourtid 2 (used in PAXml) </summary>
        [EnumMember(Value = "JR2")]
        JR2,
        ///<summary> Jourtid </summary>
        [EnumMember(Value = "JOR")]
        JOR,
        ///<summary> Jourtid (used in PAXml) </summary>
        [EnumMember(Value = "JR1")]
        JR1,
        ///<summary> Mertid </summary>
        [EnumMember(Value = "MER")]
        MER,
        ///<summary> OB-ersättning 1 </summary>
        [EnumMember(Value = "OB1")]
        OB1,
        ///<summary> OB-ersättning 2 </summary>
        [EnumMember(Value = "OB2")]
        OB2,
        ///<summary> OB-ersättning 3 </summary>
        [EnumMember(Value = "OB3")]
        OB3,
        ///<summary> OB-ersättning 4 </summary>
        [EnumMember(Value = "OB4")]
        OB4,
        ///<summary> OB-ersättning 5 </summary>
        [EnumMember(Value = "OB5")]
        OB5,
        ///<summary> Extratid - Komptid </summary>
        [EnumMember(Value = "OK0")]
        OK0,
        ///<summary> Extratid - Komptid (used in PAXml) </summary>
        [EnumMember(Value = "NV9")]
        NV9,
        ///<summary> Övertid 1 - Komptid </summary>
        [EnumMember(Value = "OK1")]
        OK1,
        ///<summary> Övertid 1 - Komptid (used in PAXml) </summary>
        [EnumMember(Value = "ÖK1")]
        ÖK1,
        ///<summary> Övertid 2 - Komptid </summary>
        [EnumMember(Value = "OK2")]
        OK2,
        ///<summary> Övertid 2 - Komptid (used in PAXml) </summary>
        [EnumMember(Value = "ÖK2")]
        ÖK2,
        ///<summary> Övertid 3 - Komptid </summary>
        [EnumMember(Value = "OK3")]
        OK3,
        ///<summary> Övertid 3 - Komptid (used in PAXml) </summary>
        [EnumMember(Value = "ÖK3")]
        ÖK3,
        ///<summary> Övertid 4 - Komptid </summary>
        [EnumMember(Value = "OK4")]
        OK4,
        ///<summary> Övertid 4 - Komptid (used in PAXml) </summary>
        [EnumMember(Value = "ÖK4")]
        ÖK4,
        ///<summary> Övertid 5 - Komptid </summary>
        [EnumMember(Value = "OK5")]
        OK5,
        ///<summary> Övertid 5 - Komptid (used in PAXml) </summary>
        [EnumMember(Value = "ÖK5")]
        ÖK5,
        ///<summary> Övertid 1 - Betalning </summary>
        [EnumMember(Value = "OT1")]
        OT1,
        ///<summary> Övertid 1 - Betalning (used in PAXml) </summary>
        [EnumMember(Value = "ÖT1")]
        ÖT1,
        ///<summary> Övertid 2 - Betalning </summary>
        [EnumMember(Value = "OT2")]
        OT2,
        ///<summary> Övertid 2 - Betalning (used in PAXml) </summary>
        [EnumMember(Value = "ÖT2")]
        ÖT2,
        ///<summary> Övertid 3 - Betalning </summary>
        [EnumMember(Value = "OT3")]
        OT3,
        ///<summary> Övertid 3 - Betalning (used in PAXml) </summary>
        [EnumMember(Value = "ÖT3")]
        ÖT3,
        ///<summary> Övertid 4 - Betalning </summary>
        [EnumMember(Value = "OT4")]
        OT4,
        ///<summary> Övertid 4 - Betalning (used in PAXml) </summary>
        [EnumMember(Value = "ÖT4")]
        ÖT4,
        ///<summary> Övertid 5 - Betalning </summary>
        [EnumMember(Value = "OT5")]
        OT5,
        ///<summary> Övertid 5 - Betalning (used in PAXml) </summary>
        [EnumMember(Value = "ÖT5")]
        ÖT5,
        ///<summary> Restid </summary>
        [EnumMember(Value = "RES")]
        RES,
        ///<summary> Restid (used in PAXml) </summary>
        [EnumMember(Value = "RE1")]
        RE1,
        ///<summary> Arbetstid </summary>
        [EnumMember(Value = "TID")]
        TID,
    }
}
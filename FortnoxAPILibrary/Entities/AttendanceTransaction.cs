using System;
using System.Xml.Serialization;
using FortnoxAPILibrary.Connectors;

namespace FortnoxAPILibrary.Entities
{
    [XmlRoot(ElementName = "AttendanceTransaction")]
    public class AttendanceTransaction
    {

        ///<summary> Unique employee-id </summary>
        [XmlElement(ElementName = "EmployeeId")]
        public string EmployeeId { get; set; }

        ///<summary> Cause code </summary>
        [XmlElement(ElementName = "CauseCode")]
        public AttendanceCauseCode CauseCode { get; set; }

        ///<summary> Date </summary>
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }

        ///<summary> Amount of hours </summary>
        [XmlElement(ElementName = "Hours")]
        public decimal? Hours { get; set; }

        ///<summary> Cost Center </summary>
        [XmlElement(ElementName = "CostCenter")]
        public string CostCenter { get; set; }

        ///<summary> Project </summary>
        [XmlElement(ElementName = "Project")]
        public string Project { get; set; }
    }

    public enum AttendanceCauseCode
    {
        ///<summary> Timlön </summary>
        [XmlEnum("ARB")]
        ARB,

        ///<summary> Beredskapstid 2 </summary>
        [XmlEnum("BE2")]
        BE2,

        ///<summary> Beredskapstid </summary>
        [XmlEnum("BER")]
        BER,

        ///<summary> Beredskapstid (used in PAXml) </summary>
        [XmlEnum("BE1")]
        BE1,

        ///<summary> Flextid +/- </summary>
        [XmlEnum("FLX")]
        FLX,

        ///<summary> HelglÖn </summary>
        [XmlEnum("HLG")]
        HLG,

        ///<summary> Jourtid 2 </summary>
        [XmlEnum("JO2")]
        JO2,

        ///<summary> Jourtid 2 (used in PAXml) </summary>
        [XmlEnum("JR2")]
        JR2,

        ///<summary> Jourtid </summary>
        [XmlEnum("JOR")]
        JOR,

        ///<summary> Jourtid (used in PAXml) </summary>
        [XmlEnum("JR1")]
        JR1,

        ///<summary> Mertid </summary>
        [XmlEnum("MER")]
        MER,

        ///<summary> OB-ersättning 1 </summary>
        [XmlEnum("OB1")]
        OB1,

        ///<summary> OB-ersättning 2 </summary>
        [XmlEnum("OB2")]
        OB2,

        ///<summary> OB-ersättning 3 </summary>
        [XmlEnum("OB3")]
        OB3,

        ///<summary> OB-ersättning 4 </summary>
        [XmlEnum("OB4")]
        OB4,

        ///<summary> OB-ersättning 5 </summary>
        [XmlEnum("OB5")]
        OB5,

        ///<summary> Extratid - Komptid </summary>
        [XmlEnum("OK0")]
        OK0,

        ///<summary> Extratid - Komptid (used in PAXml) </summary>
        [XmlEnum("NV9")]
        NV9,

        ///<summary> Övertid 1 - Komptid </summary>
        [XmlEnum("OK1")]
        OK1,

        ///<summary> Övertid 1 - Komptid (used in PAXml) </summary>
        [XmlEnum("ÖK1")]
        ÖK1,

        ///<summary> Övertid 2 - Komptid </summary>
        [XmlEnum("OK2")]
        OK2,

        ///<summary> Övertid 2 - Komptid (used in PAXml) </summary>
        [XmlEnum("ÖK2")]
        ÖK2,

        ///<summary> Övertid 3 - Komptid </summary>
        [XmlEnum("OK3")]
        OK3,

        ///<summary> Övertid 3 - Komptid (used in PAXml) </summary>
        [XmlEnum("ÖK3")]
        ÖK3,

        ///<summary> Övertid 4 - Komptid </summary>
        [XmlEnum("OK4")]
        OK4,

        ///<summary> Övertid 4 - Komptid (used in PAXml) </summary>
        [XmlEnum("ÖK4")]
        ÖK4,

        ///<summary> Övertid 5 - Komptid </summary>
        [XmlEnum("OK5")]
        OK5,

        ///<summary> Övertid 5 - Komptid (used in PAXml) </summary>
        [XmlEnum("ÖK5")]
        ÖK5,

        ///<summary> Övertid 1 - Betalning </summary>
        [XmlEnum("OT1")]
        OT1,

        ///<summary> Övertid 1 - Betalning (used in PAXml) </summary>
        [XmlEnum("ÖT1")]
        ÖT1,

        ///<summary> Övertid 2 - Betalning </summary>
        [XmlEnum("OT2")]
        OT2,

        ///<summary> Övertid 2 - Betalning (used in PAXml) </summary>
        [XmlEnum("ÖT2")]
        ÖT2,

        ///<summary> Övertid 3 - Betalning </summary>
        [XmlEnum("OT3")]
        OT3,

        ///<summary> Övertid 3 - Betalning (used in PAXml) </summary>
        [XmlEnum("ÖT3")]
        ÖT3,

        ///<summary> Övertid 4 - Betalning </summary>
        [XmlEnum("OT4")]
        OT4,

        ///<summary> Övertid 4 - Betalning (used in PAXml) </summary>
        [XmlEnum("ÖT4")]
        ÖT4,

        ///<summary> Övertid 5 - Betalning </summary>
        [XmlEnum("OT5")]
        OT5,

        ///<summary> Övertid 5 - Betalning (used in PAXml) </summary>
        [XmlEnum("ÖT5")]
        ÖT5,

        ///<summary> Restid </summary>
        [XmlEnum("RES")]
        RES,

        ///<summary> Restid (used in PAXml) </summary>
        [XmlEnum("RE1")]
        RE1,

        ///<summary> Arbetstid </summary>
        [XmlEnum("TID")]
        TID,
    }
}
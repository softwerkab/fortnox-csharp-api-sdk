using System;
using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
    
    
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Vouchers
    {
        /// <remarks/>
        [XmlElement("VoucherSubset")]
        public List<VoucherSubset> VoucherSubset { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string TotalResources { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string TotalPages { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string CurrentPage { get; set; }
    }

    /// <remarks/>
    
    [Serializable]
    
    
    [XmlType(AnonymousType = true)]
    public class VoucherSubset
    {

        /// <remarks/>
        public string ReferenceNumber { get; set; }

        /// <remarks/>
        public string ReferenceType { get; set; }

        /// <remarks/>
        public string VoucherNumber { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <remarks/>
        public string Year { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string url { get; set; }
    }
}

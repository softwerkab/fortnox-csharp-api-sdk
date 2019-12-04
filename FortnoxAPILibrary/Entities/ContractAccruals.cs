using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public class ContractAccruals
    {
        /// <remarks/>
        public List<ContractAccrualSubSet> ContractAccrualSubset { get; set; }

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
    public class ContractAccrualSubSet
    {
        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        public string Period { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string url { get; set; }
    }
}

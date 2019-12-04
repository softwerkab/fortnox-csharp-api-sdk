using System.Collections.Generic;
using System.Xml.Serialization;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public class ContractAccruals
    {
        /// <remarks/>
        public List<ContractAccrualSubSet> ContractAccrualSubset { get; set; }

        /// <remarks/>
		[XmlAttributeAttribute]
        public string TotalResources { get; set; }

        /// <remarks/>
        [XmlAttributeAttribute]
        public string TotalPages { get; set; }
        
        /// <remarks/>
        [XmlAttributeAttribute]
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
        [XmlAttributeAttribute]
        public string url { get; set; }
    }
}

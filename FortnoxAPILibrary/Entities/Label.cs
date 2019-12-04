using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{

    /// <remarks/>
    public partial class Label { //TODO: Why partial? Where is other part??
        
        /// <remarks/>
        public string Description { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        [XmlAttribute]
        public string url { get; set; }
    }
}

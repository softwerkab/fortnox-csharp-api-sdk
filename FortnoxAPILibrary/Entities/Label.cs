namespace FortnoxAPILibrary {

    /// <remarks/>
    public partial class Label { //TODO: Why partial? Where is other part??
        
        /// <remarks/>
        public string Description { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [System.ComponentModel.ReadOnly(true)]
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string url { get; set; }
    }
}
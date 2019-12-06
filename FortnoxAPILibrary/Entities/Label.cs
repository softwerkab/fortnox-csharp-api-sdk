using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{

    /// <remarks/>
    public class Label {
        
        /// <remarks/>
        public string Description { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string url { get; private set; }

        /// <remarks/>
        public string Id { get; set; }
    }
}

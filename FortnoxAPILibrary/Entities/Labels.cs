using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
    
    
    public class Labels {

        /// <remarks/>
        public List<LabelSubset> LabelSubset { get; set; }

        /// <remarks/>
        public string TotalResources { get; set; }

        /// <remarks/>
        public string TotalPages { get; set; }

        /// <remarks/>
        public string CurrentPage { get; set; }
    }

    /// <remarks/>
    [Serializable]
    public class LabelSubset {

        /// <remarks/>
        public string Id { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string url { get; set; }
    }
}

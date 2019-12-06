using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
    
    
    public class Vouchers
    {
        /// <remarks/>
        public List<VoucherSubset> VoucherSubset { get; set; }

        /// <remarks/>
        public string TotalResources { get; set; }

        /// <remarks/>
        public string TotalPages { get; set; }

        /// <remarks/>
        public string CurrentPage { get; set; }
    }

    /// <remarks/>
    
    [Serializable]
    
    
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
        public string url { get; set; }
    }
}

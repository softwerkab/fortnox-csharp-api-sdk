using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    public class ContractAccruals
    {
        /// <remarks/>
        public List<ContractAccrualSubSet> ContractAccrualSubset { get; set; }

        /// <remarks/>
        public string TotalResources { get; set; }

        /// <remarks/>
        public string TotalPages { get; set; }
        
        /// <remarks/>
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
        public string url { get; set; }
    }
}

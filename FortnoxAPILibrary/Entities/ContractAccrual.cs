using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public class ContractAccrual
    {
		/// <remarks/>
		public string AccrualAccount { get; set; }

		/// <remarks/>
		public string CostAccount { get; set; }

		/// <remarks/>
		public string Description { get; set; }

		/// <remarks/>
		[XmlArrayItem("InvoiceAccrualRow", IsNullable = false)]
		public List<InvoiceAccrualRow> AccrualRows { get; set; }

        /// <remarks/>
        public string DocumentNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Period { get; set; }

        /// <remarks/>
        public string RevenueAccount { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Times { get; set; }

        /// <remarks/>
        public string Total { get; set; }

        /// <remarks/>
        public string VATIncluded { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [XmlAttribute, ReadOnly(true)]
        public string url { get; set; }
    }
}

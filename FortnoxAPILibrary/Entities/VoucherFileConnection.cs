using System;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	public class VoucherFileConnection
	{
        /// <remarks/>
		public string FileId { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string VoucherDescription { get; private set; }

        /// <remarks/>
        public string VoucherNumber { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string VoucherYear { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string url { get; private set; }
    }
}

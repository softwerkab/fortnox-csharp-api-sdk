using System;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	public class VoucherFileConnection
	{
        /// <remarks/>
		public string FileId { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherDescription { get; set; }

        /// <remarks/>
        public string VoucherNumber { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherYear { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string url { get; set; }
    }
}

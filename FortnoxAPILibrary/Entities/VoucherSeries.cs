using System;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	public class VoucherSeries
	{
		/// <remarks/>
		public string Code { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Manual { get; set; }

        /// <remarks/>
        public string NextVoucherNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Year { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string url { get; set; }
    }
}

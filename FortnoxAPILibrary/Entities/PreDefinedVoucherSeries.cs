using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    public class PreDefinedVoucherSeries {

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public PreDefinedVoucherSeriesConnector.PreDefinedVoucherSeriesName Name { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string url { get; set; }
    }
}

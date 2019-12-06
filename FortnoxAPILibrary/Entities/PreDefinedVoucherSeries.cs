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
        public PreDefinedVoucherSeriesConnector.PreDefinedVoucherSeriesName Name { get; private set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string url { get; private set; }
    }
}

using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

    /// <remarks/>
    public class PreDefinedVoucherSeriesCollection {
        /// <remarks/>
        public List<PreDefinedVoucherSeriesSubset> PreDefinedVoucherSeriesSubset { get; set; }
    }

    /// <remarks/>
    public class PreDefinedVoucherSeriesSubset {
        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <remarks/>
        public string url { get; set; }
    }
}

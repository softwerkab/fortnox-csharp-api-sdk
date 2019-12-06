using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

    /// <remarks/>
    [Serializable]
    public class PreDefinedVoucherSeriesCollection {
        /// <remarks/>
        public List<PreDefinedVoucherSeriesSubset> PreDefinedVoucherSeriesSubset { get; set; }
    }

    /// <remarks/>
    [Serializable]
    public class PreDefinedVoucherSeriesSubset {
        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <remarks/>
        public string url { get; set; }
    }
}

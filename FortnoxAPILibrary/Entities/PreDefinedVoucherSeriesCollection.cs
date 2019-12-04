using System;
using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

/// <remarks/>
[Serializable]
[XmlType(AnonymousType=true)]
[XmlRoot(Namespace="", IsNullable=false)]
public class PreDefinedVoucherSeriesCollection {
    /// <remarks/>
    [XmlElement("PreDefinedVoucherSeriesSubset")]
    public List<PreDefinedVoucherSeriesSubset> PreDefinedVoucherSeriesSubset { get; set; }
}

/// <remarks/>
[Serializable]
[XmlType(AnonymousType=true)]
public class PreDefinedVoucherSeriesSubset {
    /// <remarks/>
    public string Name { get; set; }

    /// <remarks/>
    public string VoucherSeries { get; set; }

    /// <remarks/>
    [XmlAttribute]
    public string url { get; set; }
}

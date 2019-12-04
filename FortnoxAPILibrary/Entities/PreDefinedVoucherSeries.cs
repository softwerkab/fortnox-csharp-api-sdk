using System;
using System.ComponentModel;
using System.Xml.Serialization;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

/// <remarks/>
[Serializable]
[XmlType(AnonymousType=true)]
[XmlRoot(Namespace="", IsNullable=false)]
public class PreDefinedVoucherSeries {

    /// <summary>This field is Read-Only in Fortnox</summary>
	[XmlAttribute]
	[ReadOnly(true)]
	public PreDefinedVoucherSeriesConnector.PreDefinedVoucherSeriesName Name { get; set; }

    /// <remarks/>
    public string VoucherSeries { get; set; }

    /// <summary>This field is Read-Only in Fortnox</summary>
    [XmlAttribute]
	[ReadOnly(true)]
    public string url { get; set; }
}

using System.Collections.Generic;


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public class PreDefinedVoucherSeriesCollection {
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PreDefinedVoucherSeriesSubset")]
    public List<PreDefinedVoucherSeriesSubset> PreDefinedVoucherSeriesSubset { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public class PreDefinedVoucherSeriesSubset {
    /// <remarks/>
    public string Name { get; set; }

    /// <remarks/>
    public string VoucherSeries { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string url { get; set; }
}

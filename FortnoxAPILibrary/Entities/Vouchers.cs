using System.Collections.Generic;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class Vouchers {
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("VoucherSubset")]
    public List<VoucherSubset> VoucherSubset { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
	public string TotalResources { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
	public string TotalPages { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
	public string CurrentPage { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class VoucherSubset {
    
    /// <remarks/>
	public string ReferenceNumber { get; set; }

    /// <remarks/>
    public string ReferenceType { get; set; }

    /// <remarks/>
    public string VoucherNumber { get; set; }

    /// <remarks/>
    public string VoucherSeries { get; set; }

    /// <remarks/>
    public string Year { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string url { get; set; }
}

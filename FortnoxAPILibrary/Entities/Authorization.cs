using System;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

/// <remarks/>
[Serializable]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false)]
public class Authorization {
    
    /// <remarks/>
    public string AccessToken { get; set; }
}

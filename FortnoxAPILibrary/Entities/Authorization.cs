using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Xml.Serialization;

/// <remarks/>
[Serializable]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false)]
public class Authorization {
    
    /// <remarks/>
    public string AccessToken { get; set; }
}

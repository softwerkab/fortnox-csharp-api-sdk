using System;
using System.Collections.Generic;
using System.Xml.Serialization;
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary
{
	/// <remarks/>
	[Serializable]
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class AccountCharts
	{
        /// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("AccountChartSubset")]
		public List<AccountChartSubset> AccountChartSubset { get; set; }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class AccountChartSubset
	{
		/// <remarks/>
		public string Name { get; set; }
    }
}
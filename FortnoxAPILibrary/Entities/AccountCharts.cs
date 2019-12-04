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
		[XmlElement("AccountChartSubset")]
		public List<AccountChartSubset> AccountChartSubset { get; set; }
    }

	/// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	public class AccountChartSubset
	{
		/// <remarks/>
		public string Name { get; set; }
    }
}

using System;
using System.Xml.Schema;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary
{
	/// <remarks/>
	[Serializable]
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class ErrorInformation
	{
		/// <remarks/>
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string Error { get; set; }

		/// <remarks/>
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string Message { get; set; }

		/// <remarks/>
		[XmlElement(Form = XmlSchemaForm.Unqualified)]
		public string Code { get; set; }
	}
}
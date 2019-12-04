using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class CostCenter
	{
        /// <summary>
		/// <para>Code of the cost center</para>
		/// <para>Limits:		6 chars, a-z, 0.9</para>
		/// <para>Required:		Yes</para>
		/// <para>Type:			String</para>
		/// <para>Permissions:	RW</para>
		/// </summary>
		public string Code { get; set; }

        /// <summary>
        /// <para>Description of the cost center</para>
        /// <para>Required:		No</para>
        /// <para>Type:			String</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// <para>Note</para>
        /// <para>Required:		No</para>
        /// <para>Type:			String</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// <para>Status of the cost center</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Bool</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        public string Active { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		[ReadOnly(true)]
		public string url { get; set; }
    }
}

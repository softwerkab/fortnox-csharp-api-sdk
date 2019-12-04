using System;
using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class Currency
	{
        /// <summary>
		/// <para>The buy rate of the currency</para>
		/// <para>Required:		No</para>
		/// <para>Type:			Float</para>
		/// <para>Permissions:	RW</para>
		/// </summary>
		public string BuyRate { get; set; }

        /// <summary>
        /// <para>Code of the currency</para>
        /// <para>Required:		Yes</para>
        /// <para>Limits:		3 chars, A-Z</para>
        /// <para>Type:			String</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// <para>Date of creation</para>
        /// <para>Type:			Date</para>
        /// <para>Permissions:	R</para>
        /// </summary>
        [ReadOnly(true)]
		public string Date { get; set; }

        /// <summary>
        /// <para>Description of the currency</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Date</para>
        /// <para>Permissions:	R</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// <para>The sell rate of the currency</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Float</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        public string SellRate { get; set; }

        /// <summary>
        /// <para>The unit of the currency</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Float</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        public string Unit { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [XmlAttribute]
		[ReadOnly(true)]
		public string url { get; set; }
    }
}


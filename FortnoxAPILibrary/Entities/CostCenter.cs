using System;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
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
		[ReadOnly(true)]
		public string url { get; set; }
    }
}

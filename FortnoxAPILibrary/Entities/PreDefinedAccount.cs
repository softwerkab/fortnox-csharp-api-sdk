using System;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	public class PreDefinedAccount
	{
        /// <remarks/>
		public string Account { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Name { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string url { get; private set; }
    }
}

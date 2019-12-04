using System;
using System.ComponentModel;
using System.Xml.Serialization;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary
{
    /// <remarks/>
    [Serializable]
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]

    public class Account
	{
        /// <remarks/>
		public string Active { get; set; }

        /// <remarks/>
        public string BalanceBroughtForward { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string BalanceCarriedForward { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <remarks/>
        public AccountConnector.CostCenterSettingsValue? CostCenterSettings { get; set; }
        public bool ConstCenterSettingsSpecified => CostCenterSettings != null;

		/// <remarks/>
		public string Description { get; set; }

        /// <remarks/>
        public string Number { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <remarks/>
        public AccountConnector.ProjectSettingsValue? ProjectSettings { get; set; }
        public bool ProjectSettingsSpecified => ProjectSettings != null;

        /// <remarks/>
        public string SRU { get; set; }

        /// <remarks/>
        public string TransactionInformation { get; set; }

        /// <remarks/>
        public AccountConnector.TransactionInfoSettingsValue? TransactionInformationSettings { get; set; }
        public bool TransactionInformationSettingsSpecified => TransactionInformationSettings != null;

        /// <remarks/>
        public string VATCode { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Year { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [XmlAttribute]
		[ReadOnly(true)]
		public string url { get; set; }
    }
}

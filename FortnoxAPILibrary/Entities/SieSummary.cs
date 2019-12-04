using System;
using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class SieSummary
	{
        /// <remarks/>
		public string Accounts { get; set; }

        /// <remarks/>
        public string ContactName { get; set; }

        /// <remarks/>
        public string ContactDeliveryAddress { get; set; }

        /// <remarks/>
        public string ContactMailingAddress { get; set; }

        /// <remarks/>
        public string ContactPhone { get; set; }

        /// <remarks/>
        public string CostCenters { get; set; }

        /// <remarks/>
        public string DateOfGeneration { get; set; }

        /// <remarks/>
        public string Extent { get; set; }

        /// <remarks/>
        public string IncomingBalances { get; set; }

        /// <remarks/>
        public string Projects { get; set; }

        /// <remarks/>
        public string TermBudgets { get; set; }

        /// <remarks/>
        public string TypeOfSie { get; set; }

        /// <remarks/>
        public string UsedAccounts { get; set; }

        /// <remarks/>
        public string UsedCostCenters { get; set; }

        /// <remarks/>
        public string UsedProjects { get; set; }

        /// <remarks/>
        public string Verifications { get; set; }

        /// <remarks/>
        [XmlArrayItem("VerificationInterval", IsNullable = false)]
		public List<VerificationInterval> VerificationsIntervals { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	
	
	[XmlType(AnonymousType = true)]
	public class VerificationInterval
	{
        /// <remarks/>
		public string First { get; set; }

        /// <remarks/>
        public string Last { get; set; }

        /// <remarks/>
        public string Series { get; set; }
    }
}

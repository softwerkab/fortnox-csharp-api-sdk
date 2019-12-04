using System.Collections.Generic;

namespace FortnoxAPILibrary
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class SieSummary
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
        [System.Xml.Serialization.XmlArrayItemAttribute("VerificationInterval", IsNullable = false)]
		public List<VerificationInterval> VerificationsIntervals { get; set; }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class VerificationInterval
	{
        /// <remarks/>
		public string First { get; set; }

        /// <remarks/>
        public string Last { get; set; }

        /// <remarks/>
        public string Series { get; set; }
    }
}
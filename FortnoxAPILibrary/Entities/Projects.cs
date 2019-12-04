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
	public partial class Projects
	{
        /// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ProjectSubset")]
		public List<ProjectSubset> ProjectSubset { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string TotalResources { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string TotalPages { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ProjectSubset
	{
        /// <remarks/>
		public string Description { get; set; }

        /// <remarks/>
        public string EndDate { get; set; }

        /// <remarks/>
        public string ProjectNumber { get; set; }

        /// <remarks/>
        public string Status { get; set; }

        /// <remarks/>
        public string StartDate { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }
    }
}
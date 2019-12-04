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
	public class Folder
	{
        /// <remarks/>
		public string Email { get; set; }

        /// <remarks/>
        public Files Files { get; set; }

        /// <remarks/>
        public Folders Folders { get; set; }

        /// <remarks/>
        public string Id { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class Files
	{
        /// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("File")]
		public List<File> File { get; set; }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class File
	{
        /// <summary>
		/// Actual Content Type if file data is manually downloaded from archive.
		/// </summary>
		[System.Xml.Serialization.XmlIgnore]
		public string ContentType { get; set; }

		/// <summary>
		/// Actual file data if manually downloaded from archive.
		/// </summary>
		[System.Xml.Serialization.XmlIgnore]
		public byte[] Data { get; set; }

		/// <remarks/>
		public string Comments { get; set; }

        /// <remarks/>
        public string Id { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string Path { get; set; }

        /// <remarks/>
        public string Size { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }

        /// <remarks/>
        public string GetFileExtension()
		{
			if (string.IsNullOrEmpty(this.Name))
			{
				return "";
			}

			return System.IO.Path.GetExtension(this.Name);
		}

		/// <remarks/>
		public string GetFileNameWithoutExtension()
		{
			if (string.IsNullOrEmpty(this.Name))
			{
				return "";
			}

			return System.IO.Path.GetFileNameWithoutExtension(this.Name);
		}

		/// <remarks/>
		public System.IO.MemoryStream GetFileDataAsMemoryStream()
		{
			if (this.Data == null)
			{
				throw new System.Exception("File data must be set.");
			}

			return new System.IO.MemoryStream(this.Data);
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class Folders
	{
        /// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Folder")]
		public List<FoldersFolder> Folder { get; set; }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class FoldersFolder
	{
        /// <remarks/>
		public string Id { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }
    }
}
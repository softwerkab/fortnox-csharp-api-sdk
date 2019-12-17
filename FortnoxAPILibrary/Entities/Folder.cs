using System;
using System.Collections.Generic;
using System.IO;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "Folder", PluralName = "Folders")]
	public class Folder 
	{
        /// <remarks/>
		[JsonProperty]
		public string Email { get; set; }

        /// <remarks/>
        [JsonProperty]
        public List<File> Files { get; set; }

        /// <remarks/>
        [JsonProperty]
        public List<FolderSubset> Folders { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Id { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }

	/// <remarks/>
    [Entity(SingularName = "File", PluralName = "Files")]
    public class File
	{
        /// <summary>
		/// Actual Content Type if file data is manually downloaded from archive.
		/// </summary>
		[JsonProperty]
		public string ContentType { get; set; }

		/// <summary>
		/// Actual file data if manually downloaded from archive.
		/// </summary>
		[JsonProperty]
		public byte[] Data { get; set; }

		/// <remarks/>
		[JsonProperty]
		public string Comments { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Id { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Path { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Size { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }

        /// <remarks/>
        public string GetFileExtension()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return "";
			}

			return System.IO.Path.GetExtension(Name);
		}

		/// <remarks/>
		public string GetFileNameWithoutExtension()
		{
			if (string.IsNullOrEmpty(Name))
			{
				return "";
			}

			return System.IO.Path.GetFileNameWithoutExtension(Name);
		}

		/// <remarks/>
		public MemoryStream GetFileDataAsMemoryStream()
		{
			if (Data == null)
			{
				throw new Exception("File data must be set.");
			}

			return new MemoryStream(Data);
		}
	}

	/// <remarks/>
    [Entity(SingularName = "Folder", PluralName = "Folders")]
    public class FolderSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Id { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
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
		public string url { get; set; }
    }

	/// <remarks/>
    [Serializable]
	public class Files
	{
        /// <remarks/>
		public List<File> File { get; set; }
    }

	/// <remarks/>
    [Serializable]
	public class File
	{
        /// <summary>
		/// Actual Content Type if file data is manually downloaded from archive.
		/// </summary>
		public string ContentType { get; set; }

		/// <summary>
		/// Actual file data if manually downloaded from archive.
		/// </summary>
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
		public string url { get; set; }

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
    [Serializable]
	public class Folders
	{
        /// <remarks/>
		public List<FoldersFolder> Folder { get; set; }
    }

	/// <remarks/>
    [Serializable]
	public class FoldersFolder
	{
        /// <remarks/>
		public string Id { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}

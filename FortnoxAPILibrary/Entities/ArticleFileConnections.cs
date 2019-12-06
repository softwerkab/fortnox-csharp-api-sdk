using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    public class ArticleFileConnections
	{
        /// <remarks/>
		public List<ArticleFileConnectionSubset> ArticleFileConnectionSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	public class ArticleFileConnectionSubset
	{
		/// <remarks/>
		public string FileId { get; set; }

        /// <remarks/>
        public string ArticleNumber { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}

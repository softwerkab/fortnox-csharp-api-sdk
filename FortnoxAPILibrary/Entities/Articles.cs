using System;
using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    public class Articles
	{

		/// <remarks/>
		public List<ArticleSubset> ArticleSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	public class ArticleSubset
	{
        /// <remarks/>
		public string ArticleNumber { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string DisposableQuantity { get; set; }

        /// <remarks/>
        public string EAN { get; set; }

        /// <remarks/>
        public string Housework { get; set; }

        /// <remarks/>
        public string PurchasePrice { get; set; }

        /// <remarks/>
	    public string SalesPrice { get; private set; }

        /// <remarks/>
        public string QuantityInStock { get; set; }

        /// <remarks/>
        public string ReservedQuantity { get; set; }

        /// <remarks/>
        public string StockPlace { get; set; }

        /// <remarks/>
        public string StockValue { get; set; }

        /// <remarks/>
        public string Unit { get; set; }

        /// <remarks/>
        public string VAT { get; set; }

        /// <remarks/>
		public string url { get; set; }

        /// <remarks/>
        public string WebshopArticle { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary
{
    /// <summary>
    /// Base settings for filtering search results.
    /// More info at official <see href="https://developer.fortnox.se/general/parameters/">documentation</see>
    /// </summary>
    public class BaseSearch
    {
        /// <summary>
        /// Limit search result to entities modified after specified date
        /// </summary>
        [SearchParameter]
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Limit search result to entities relevant to specified financial year
        /// </summary>
        [SearchParameter("financialyear")]
        public long? FinancialYearID { get; set; }

        /// <summary>
        /// Limit search result to entities relevant to financial year to which this date belongs.
        /// Note, financial years don't overlap, therefore a date defines one (or none) financial year 
        /// </summary>
        [SearchParameter]
        public DateTime? FinancialYearDate { get; set; }

        /// <summary>
        /// Limits search result to entities with date (e.g. InvoiceDate) after specified date
        /// Only available for invoices, orders, offers and vouchers.
        /// </summary>
        [SearchParameter]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Limits search result to entities with date (e.g. InvoiceDate) before specified date
        /// Only available for invoices, orders, offers and vouchers.
        /// </summary>
        [SearchParameter]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Defines order for search result
        /// </summary>
        [SearchParameter]
        public Sort.Order? SortOrder { get; set; }

        /// <summary>
        /// Defines page size for the search result. If undefined, API uses page size 100.
        /// APIConstants.MaxLimit and APIConstants.Unlimited can be used.
        /// </summary>
        [SearchParameter]
        public int? Limit { get; set; }

        /// <summary>
        /// Defines which page should be retrieved. If undefined, API uses page 1
        /// </summary>
        [SearchParameter]
        public int? Page { get; set; }

        /// <summary>
        /// Skips specified amount of entities from search result. If undefined, API uses 0
        /// </summary>
        [SearchParameter]
        public int? Offset { get; set; }


        internal Dictionary<string, string> GetSearchParameters()
        {
            var searchParams = new Dictionary<string, string>();

            foreach (var property in GetType().GetProperties())
            {
                var isSearchParameter = property.HasAttribute<SearchParameter>();
                if (!isSearchParameter) continue;

                var value = property.GetValue(this);
                var strValue = Utils.GetStringValue(value, property.PropertyType);
                if (string.IsNullOrWhiteSpace(strValue)) continue;

                var searchAttribute = property.GetAttribute<SearchParameter>();
                var paramName = searchAttribute.Name ?? property.Name;

                searchParams.Add(paramName.ToLower(), strValue);
            }

            return searchParams;
        }
    }
}

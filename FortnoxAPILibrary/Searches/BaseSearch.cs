using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary
{
    public class BaseSearch
    {
        [SearchParameter]
        public DateTime? LastModified { get; set; }

        [SearchParameter("financialyear")]
        public long? FinancialYearID { get; set; }

        [SearchParameter]
        public DateTime? FinancialYearDate { get; set; }

        [SearchParameter]
        public DateTime? FromDate { get; set; }

        [SearchParameter]
        public DateTime? ToDate { get; set; }


        [SearchParameter]
        public Sort.Order? SortOrder { get; set; }

        [SearchParameter]
        public int? Limit { get; set; }

        [SearchParameter]
        public int? Page { get; set; }

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

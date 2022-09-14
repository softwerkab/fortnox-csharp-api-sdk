using System;
using System.Collections.Generic;
using System.Linq;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Search;

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
    public virtual DateTime? FinancialYearDate { get; set; }

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

        foreach (var property in GetType().GetProperties().Where(p => p.HasAttribute<SearchParameter>()))
        {
            var value = property.GetValue(this);
            var strValue = Utils.GetStringValue(value, property.PropertyType);
            if (string.IsNullOrWhiteSpace(strValue)) continue;

            var searchAttribute = property.GetAttribute<SearchParameter>();
            var paramName = searchAttribute.Name ?? property.Name;

            searchParams.Add(paramName.ToLower(), strValue);
        }

        if (CustomParameters != null)
        {
            foreach (var parameter in CustomParameters)
                searchParams.Add(parameter.Key, parameter.Value);
        }

        return searchParams;
    }

    /// <summary>
    /// Use as a workaround for parameters not defined explicitly.
    /// Please report the missing parameters on GitHub repository so they can be added.
    /// </summary>
    public Dictionary<string, string> CustomParameters { get; set; } = new Dictionary<string, string>();
}
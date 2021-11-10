namespace Fortnox.SDK.Search;

public class SupplierInvoiceExternalURLConnectionSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.SupplierInvoiceExternalURLConnection? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.SupplierInvoiceExternalURLConnection? FilterBy { get; set; }


}
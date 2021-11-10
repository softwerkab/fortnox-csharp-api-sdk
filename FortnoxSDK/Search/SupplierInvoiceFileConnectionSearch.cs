namespace Fortnox.SDK.Search;

public class SupplierInvoiceFileConnectionSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.SupplierInvoiceFileConnection? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.SupplierInvoiceFileConnection? FilterBy { get; set; }


    [SearchParameter]
    public string SupplierInvoiceNumber { get; set; }
}
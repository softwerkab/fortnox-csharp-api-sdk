namespace Fortnox.SDK.Search;

public class SupplierInvoiceAccrualSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.SupplierInvoiceAccrual? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.SupplierInvoiceAccrual? FilterBy { get; set; }


}
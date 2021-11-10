namespace Fortnox.SDK.Search;

public class SupplierInvoicePaymentSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.SupplierInvoicePayment? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.SupplierInvoicePayment? FilterBy { get; set; }


    [SearchParameter]
    public string InvoiceNumber { get; set; }
}
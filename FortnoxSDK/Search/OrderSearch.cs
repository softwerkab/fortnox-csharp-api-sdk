namespace Fortnox.SDK.Search;

public class OrderSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.Order? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.Order? FilterBy { get; set; }


    [SearchParameter]
    public string CostCenter { get; set; }

    [SearchParameter]
    public string CustomerName { get; set; }

    [SearchParameter]
    public string CustomerNumber { get; set; }

    [SearchParameter]
    public string DocumentNumber { get; set; }

    [SearchParameter]
    public string ExternalInvoiceReference1 { get; set; }

    [SearchParameter]
    public string ExternalInvoiceReference2 { get; set; }

    [SearchParameter]
    public string OrderDate { get; set; }

    [SearchParameter]
    public string OurReference { get; set; }

    [SearchParameter]
    public string Project { get; set; }

    [SearchParameter]
    public string Sent { get; set; }

    [SearchParameter]
    public string YourReference { get; set; }
}
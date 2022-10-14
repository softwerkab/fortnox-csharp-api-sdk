namespace Fortnox.SDK.Search;

public class CustomerReferenceSearch : BaseSearch
{
    [SearchParameter("customer")]
    public string Customer { get; set; }
}

namespace Fortnox.SDK.Search;

public class SupplierSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.Supplier? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.Supplier? FilterBy { get; set; }


    [SearchParameter]
    public string City { get; set; }

    [SearchParameter]
    public string Email { get; set; }

    [SearchParameter]
    public string Name { get; set; }

    [SearchParameter]
    public string OrganisationNumber { get; set; }

    [SearchParameter]
    public string Phone1 { get; set; }

    [SearchParameter]
    public string Phone2 { get; set; }

    [SearchParameter]
    public string SupplierNumber { get; set; }

    [SearchParameter]
    public string ZipCode { get; set; }
}
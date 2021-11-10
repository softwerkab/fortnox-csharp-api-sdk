namespace Fortnox.SDK.Search;

public class ArticleSearch : BaseSearch
{
    [SearchParameter("sortby")]
    public Sort.By.Article? SortBy { get; set; }

    [SearchParameter("filter")]
    public Filter.Article? FilterBy { get; set; }


    [SearchParameter]
    public string ArticleNumber { get; set; }

    [SearchParameter]
    public string Description { get; set; }

    [SearchParameter]
    public string EAN { get; set; }

    [SearchParameter]
    public string Manufacturer { get; set; }

    [SearchParameter]
    public string ManufacturerArticleNumber { get; set; }

    [SearchParameter]
    public string SupplierNumber { get; set; }
}
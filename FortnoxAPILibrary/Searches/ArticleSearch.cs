namespace FortnoxAPILibrary
{
    public class ArticleSearch : BaseSearch
    {
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
}

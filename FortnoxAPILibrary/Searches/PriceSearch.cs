namespace FortnoxAPILibrary
{
    public class PriceSearch : BaseSearch
    {
        [SearchParameter]
		public string ArticleNumber { get; set; }

        [SearchParameter]
		public string FromQuantity { get; set; }
    }
}

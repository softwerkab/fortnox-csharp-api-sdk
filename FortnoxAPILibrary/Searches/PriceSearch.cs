namespace FortnoxAPILibrary
{
    public class PriceSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.Price? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.Price? FilterBy { get; set; }


        [SearchParameter]
		public string ArticleNumber { get; set; }

        [SearchParameter]
		public string FromQuantity { get; set; }
    }
}

namespace FortnoxAPILibrary
{
    public class ArticleFileConnectionSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.ArticleFileConnection? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.ArticleFileConnection? FilterBy { get; set; }


        [SearchParameter]
		public string ArticleNumber { get; set; }
    }
}

namespace FortnoxAPILibrary
{
    public class ArticleFileConnectionSearch : BaseSearch
    {
        [SearchParameter]
		public string ArticleNumber { get; set; }
    }
}

namespace Fortnox.SDK.Search
{
    public class ArchiveSearch : BaseSearch
    {
        [SearchParameter("sortby")]
        public Sort.By.Archive? SortBy { get; set; }

        [SearchParameter("filter")]
        public Filter.Archive? FilterBy { get; set; }


    }
}

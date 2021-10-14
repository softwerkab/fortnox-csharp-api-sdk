namespace Fortnox.SDK.Search
{
    public class ContractAccrualSearch : BaseSearch
    {
        [SearchParameter("sortby")]
        public Sort.By.ContractAccrual? SortBy { get; set; }

        [SearchParameter("filter")]
        public Filter.ContractAccrual? FilterBy { get; set; }


    }
}

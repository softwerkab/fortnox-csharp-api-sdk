namespace Fortnox.SDK.Search
{
    public class CostCenterSearch : BaseSearch
    {
        [SearchParameter("sortby")]
        public Sort.By.CostCenter? SortBy { get; set; }

        [SearchParameter("filter")]
        public Filter.CostCenter? FilterBy { get; set; }


    }
}

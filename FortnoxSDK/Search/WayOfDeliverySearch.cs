namespace Fortnox.SDK.Search
{
    public class WayOfDeliverySearch : BaseSearch
    {
        [SearchParameter("sortby")]
        public Sort.By.WayOfDelivery? SortBy { get; set; }

        [SearchParameter("filter")]
        public Filter.WayOfDelivery? FilterBy { get; set; }


    }
}

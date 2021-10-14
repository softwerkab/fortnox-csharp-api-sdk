namespace Fortnox.SDK.Search
{
    public class CompanyInformationSearch : BaseSearch
    {
        [SearchParameter("sortby")]
        public Sort.By.CompanyInformation? SortBy { get; set; }

        [SearchParameter("filter")]
        public Filter.CompanyInformation? FilterBy { get; set; }


    }
}

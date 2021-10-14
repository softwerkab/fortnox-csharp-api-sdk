namespace Fortnox.SDK.Search
{
    public class EmployeeSearch : BaseSearch
    {
        [SearchParameter("sortby")]
        public Sort.By.Employee? SortBy { get; set; }

        [SearchParameter("filter")]
        public Filter.Employee? FilterBy { get; set; }


    }
}

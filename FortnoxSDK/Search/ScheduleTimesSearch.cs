namespace Fortnox.SDK.Search
{
    public class ScheduleTimesSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.ScheduleTimes? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.ScheduleTimes? FilterBy { get; set; }


    }
}

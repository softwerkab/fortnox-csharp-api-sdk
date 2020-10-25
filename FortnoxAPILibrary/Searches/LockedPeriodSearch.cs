namespace FortnoxAPILibrary
{
    public class LockedPeriodSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.LockedPeriod? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.LockedPeriod? FilterBy { get; set; }


    }
}

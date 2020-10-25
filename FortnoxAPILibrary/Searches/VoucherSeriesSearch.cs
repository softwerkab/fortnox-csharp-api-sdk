namespace FortnoxAPILibrary
{
    public class VoucherSeriesSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.VoucherSeries? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.VoucherSeries? FilterBy { get; set; }


    }
}

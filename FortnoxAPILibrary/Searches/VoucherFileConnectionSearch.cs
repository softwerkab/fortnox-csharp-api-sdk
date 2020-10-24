namespace FortnoxAPILibrary
{
    public class VoucherFileConnectionSearch : BaseSearch
    {
		[SearchParameter]
		public string VoucherDescription { get; set; }

		[SearchParameter]
		public string VoucherNumber { get; set; }

		[SearchParameter]
		public string VoucherSeries { get; set; }
    }
}

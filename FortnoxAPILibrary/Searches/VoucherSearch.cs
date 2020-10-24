namespace FortnoxAPILibrary
{
    public class VoucherSearch : BaseSearch
    {
		[SearchParameter]
		public string CostCenter { get; set; }
    }
}

namespace FortnoxAPILibrary
{
    public class PriceListSearch : BaseSearch
    {
        [SearchParameter]
		public string Code { get; set; }

        [SearchParameter]
		public string Comments { get; set; }
    }
}

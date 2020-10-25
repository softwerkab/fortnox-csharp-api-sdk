namespace FortnoxAPILibrary
{
    public class OfferSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.Offer? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.Offer? FilterBy { get; set; }


        [SearchParameter]
		public string CostCenter { get; set; }

        [SearchParameter]
		public string CustomerName { get; set; }

        [SearchParameter]
		public string CustomerNumber { get; set; }

        [SearchParameter]
		public string DocumentNumber { get; set; }

        [SearchParameter]
		public string OfferDate { get; set; }

        [SearchParameter]
		public string OurReference { get; set; }

        [SearchParameter]
		public string Project { get; set; }

        [SearchParameter]
		public string YourReference { get; set; }
    }
}

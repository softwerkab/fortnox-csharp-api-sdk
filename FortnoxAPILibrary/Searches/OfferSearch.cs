namespace FortnoxAPILibrary
{
    public class OfferSearch : BaseSearch
    {
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

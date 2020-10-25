namespace FortnoxAPILibrary
{
    public class CustomerSearch : BaseSearch
    {
		[SearchParameter("sortby")]
		public Sort.By.Customer? SortBy { get; set; }

		[SearchParameter("filter")]
		public Filter.Customer? FilterBy { get; set; }


        [SearchParameter]
		public string City { get; set; }

        [SearchParameter]
		public string CustomerNumber { get; set; }

        [SearchParameter]
		public string Email { get; set; }

        [SearchParameter]
		public string GLN { get; set; }

        [SearchParameter]
		public string GLNDelivery { get; set; }

        [SearchParameter]
		public string Name { get; set; }

        [SearchParameter]
		public string OrganisationNumber { get; set; }

        [SearchParameter]
		public string Phone1 { get; set; }

        [SearchParameter]
		public string ZipCode { get; set; }
    }
}

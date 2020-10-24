namespace FortnoxAPILibrary
{
    public class CustomerSearch : BaseSearch
    {
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

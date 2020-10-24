namespace FortnoxAPILibrary
{
    public class SupplierSearch : BaseSearch
    {
        [SearchParameter]
		public string City { get; set; }

        [SearchParameter]
		public string Email { get; set; }

        [SearchParameter]
		public string Name { get; set; }

        [SearchParameter]
		public string OrganisationNumber { get; set; }

        [SearchParameter]
		public string Phone1 { get; set; }

        [SearchParameter]
		public string Phone2 { get; set; }

        [SearchParameter]
		public string SupplierNumber { get; set; }

        [SearchParameter]
		public string ZipCode { get; set; }
    }
}

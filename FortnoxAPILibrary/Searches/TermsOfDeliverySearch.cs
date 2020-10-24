namespace FortnoxAPILibrary
{
    public class TermsOfDeliverySearch : BaseSearch
    {
        [SearchParameter]
		public string Code { get; set; }
    }
}

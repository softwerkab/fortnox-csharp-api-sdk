namespace FortnoxAPILibrary
{
    public class ModeOfPaymentSearch : BaseSearch
    {
        [SearchParameter]
		public string Code { get; set; }
    }
}

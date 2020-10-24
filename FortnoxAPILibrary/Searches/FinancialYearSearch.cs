namespace FortnoxAPILibrary
{
    public class FinancialYearSearch : BaseSearch
    {
        [SearchParameter]
        public string Date { get; set; }
    }
}

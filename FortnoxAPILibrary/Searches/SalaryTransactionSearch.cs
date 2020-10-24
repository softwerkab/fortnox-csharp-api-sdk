namespace FortnoxAPILibrary
{
    public class SalaryTransactionSearch : BaseSearch
    {
        [SearchParameter]
        public string EmployeeId { get; set; }

        [SearchParameter]
        public string Date { get; set; }
    }
}

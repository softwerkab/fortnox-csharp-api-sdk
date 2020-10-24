namespace FortnoxAPILibrary
{
    public class PrintTemplateSearch : BaseSearch
    {
        [SearchParameter("type")]
		public Filter.PrintTemplate? FilterBy { get; set; }
    }
}

namespace FortnoxAPILibrary
{
    public class ProjectSearch : BaseSearch
    {
        [SearchParameter("description")]
		public string Description { get; set; }
    }
}

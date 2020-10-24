using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class PrintTemplateConnector : EntityConnector<PrintTemplate, EntityCollection<PrintTemplate>, Sort.By.PrintTemplate?>, IPrintTemplateConnector
	{
		public PrintTemplateSearch Search { get; set; } = new PrintTemplateSearch();

		/// <remarks/>
		public PrintTemplateConnector()
		{
			Resource = "printtemplates";
		}

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("type")]
        public Filter.PrintTemplate? FilterBy { get; set; }

		/// <summary>
		/// Gets a list of printTemplates
		/// </summary>
		/// <returns>A list of printTemplates</returns>
		public EntityCollection<PrintTemplate> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<PrintTemplate>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
	}
}

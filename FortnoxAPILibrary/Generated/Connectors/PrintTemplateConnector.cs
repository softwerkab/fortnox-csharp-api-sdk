using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class PrintTemplateConnector : EntityConnector<PrintTemplate, EntityCollection<PrintTemplateSubset>, Sort.By.PrintTemplate?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.PrintTemplate? FilterBy { get; set; }


		/// <remarks/>
		public PrintTemplateConnector()
		{
			Resource = "printtemplates";
		}
		/// <summary>
		/// Gets a list of printTemplates
		/// </summary>
		/// <returns>A list of printTemplates</returns>
		public EntityCollection<PrintTemplateSubset> Find()
		{
			return BaseFind();
		}
	}
}

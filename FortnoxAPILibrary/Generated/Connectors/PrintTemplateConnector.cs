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
		public Filter.PrintTemplate FilterBy { get; set; }


		/// <remarks/>
		public PrintTemplateConnector()
		{
			Resource = "printtemplates";
		}

		/// <summary>
		/// Find a printTemplate based on printTemplatenumber
		/// </summary>
		/// <param name="printTemplateNumber">The printTemplatenumber to find</param>
		/// <returns>The found printTemplate</returns>
		public PrintTemplate Get(string printTemplateNumber)
		{
			return BaseGet(printTemplateNumber);
		}

		/// <summary>
		/// Updates a printTemplate
		/// </summary>
		/// <param name="printTemplate">The printTemplate to update</param>
		/// <returns>The updated printTemplate</returns>
		public PrintTemplate Update(PrintTemplate printTemplate)
		{
			return BaseUpdate(printTemplate, printTemplate.PrintTemplateNumber);
		}

		/// <summary>
		/// Create a new printTemplate
		/// </summary>
		/// <param name="printTemplate">The printTemplate to create</param>
		/// <returns>The created printTemplate</returns>
		public PrintTemplate Create(PrintTemplate printTemplate)
		{
			return BaseCreate(printTemplate);
		}

		/// <summary>
		/// Deletes a printTemplate
		/// </summary>
		/// <param name="printTemplateNumber">The printTemplatenumber to delete</param>
		public void Delete(string printTemplateNumber)
		{
			BaseDelete(printTemplateNumber);
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

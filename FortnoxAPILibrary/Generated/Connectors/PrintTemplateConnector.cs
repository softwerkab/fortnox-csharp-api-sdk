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
		/// Find a printTemplate based on id
		/// </summary>
		/// <param name="id">Identifier of the printTemplate to find</param>
		/// <returns>The found printTemplate</returns>
		public PrintTemplate Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a printTemplate
		/// </summary>
		/// <param name="printTemplate">The printTemplate to update</param>
		/// <returns>The updated printTemplate</returns>
		public PrintTemplate Update(PrintTemplate printTemplate)
		{
			return BaseUpdate(printTemplate, printTemplate.Name.ToString());
		}

		/// <summary>
		/// Creates a new printTemplate
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
		/// <param name="id">Identifier of the printTemplate to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
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


using System.Collections.Generic;
namespace FortnoxAPILibrary.Connectors
{
    public interface IPrintTemplateConnector : IEntityConnector<Sort.By.PrintTemplate>
    {
        /// <summary>
        /// Gets a list of print templates
        /// </summary>
        /// <returns>A list of print templates</returns>
        PrintTemplates Find();
    }

    /// <remarks/>
	public class PrintTemplateConnector : EntityConnector<PrintTemplates, PrintTemplates, Sort.By.PrintTemplate>, IPrintTemplateConnector
    {
		/// <remarks/>
		public PrintTemplateConnector()
		{
			base.Resource = "printtemplates";
		}

		/// <summary>
		/// Gets a list of print templates
		/// </summary>
		/// <returns>A list of print templates</returns>
		public PrintTemplates Find()
		{
			return base.BaseFind();
		}
	}
}

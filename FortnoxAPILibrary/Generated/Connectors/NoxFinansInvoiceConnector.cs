using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class NoxFinansInvoiceConnector : EntityConnector<NoxFinansInvoice, EntityCollection<NoxFinansInvoiceSubset>, Sort.By.NoxFinansInvoice?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.NoxFinansInvoice FilterBy { get; set; }


		/// <remarks/>
		public NoxFinansInvoiceConnector()
		{
			Resource = "noxfinansinvoices";
		}

		/// <summary>
		/// Find a noxFinansInvoice based on noxFinansInvoicenumber
		/// </summary>
		/// <param name="noxFinansInvoiceNumber">The noxFinansInvoicenumber to find</param>
		/// <returns>The found noxFinansInvoice</returns>
		public NoxFinansInvoice Get(string noxFinansInvoiceNumber)
		{
			return BaseGet(noxFinansInvoiceNumber);
		}

		/// <summary>
		/// Updates a noxFinansInvoice
		/// </summary>
		/// <param name="noxFinansInvoice">The noxFinansInvoice to update</param>
		/// <returns>The updated noxFinansInvoice</returns>
		public NoxFinansInvoice Update(NoxFinansInvoice noxFinansInvoice)
		{
			return BaseUpdate(noxFinansInvoice, noxFinansInvoice.NoxFinansInvoiceNumber);
		}

		/// <summary>
		/// Create a new noxFinansInvoice
		/// </summary>
		/// <param name="noxFinansInvoice">The noxFinansInvoice to create</param>
		/// <returns>The created noxFinansInvoice</returns>
		public NoxFinansInvoice Create(NoxFinansInvoice noxFinansInvoice)
		{
			return BaseCreate(noxFinansInvoice);
		}

		/// <summary>
		/// Deletes a noxFinansInvoice
		/// </summary>
		/// <param name="noxFinansInvoiceNumber">The noxFinansInvoicenumber to delete</param>
		public void Delete(string noxFinansInvoiceNumber)
		{
			BaseDelete(noxFinansInvoiceNumber);
		}

		/// <summary>
		/// Gets a list of noxFinansInvoices
		/// </summary>
		/// <returns>A list of noxFinansInvoices</returns>
		public EntityCollection<NoxFinansInvoiceSubset> Find()
		{
			return BaseFind();
		}
	}
}

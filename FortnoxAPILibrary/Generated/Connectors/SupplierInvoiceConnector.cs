using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceConnector : EntityConnector<SupplierInvoice, EntityCollection<SupplierInvoiceSubset>, Sort.By.SupplierInvoice?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.SupplierInvoice? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CostCenter { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string OCR { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Project { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string SupplierNumber { get; set; }

		/// <remarks/>
		public SupplierInvoiceConnector()
		{
			Resource = "supplierinvoices";
		}

		/// <summary>
		/// Find a supplierInvoice based on id
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoice to find</param>
		/// <returns>The found supplierInvoice</returns>
		public SupplierInvoice Get(long? id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a supplierInvoice
		/// </summary>
		/// <param name="supplierInvoice">The supplierInvoice to update</param>
		/// <returns>The updated supplierInvoice</returns>
		public SupplierInvoice Update(SupplierInvoice supplierInvoice)
		{
			return BaseUpdate(supplierInvoice, supplierInvoice.GivenNumber.ToString());
		}

		/// <summary>
		/// Creates a new supplierInvoice
		/// </summary>
		/// <param name="supplierInvoice">The supplierInvoice to create</param>
		/// <returns>The created supplierInvoice</returns>
		public SupplierInvoice Create(SupplierInvoice supplierInvoice)
		{
			return BaseCreate(supplierInvoice);
		}

		/// <summary>
		/// Deletes a supplierInvoice
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoice to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of supplierInvoices
		/// </summary>
		/// <returns>A list of supplierInvoices</returns>
		public EntityCollection<SupplierInvoiceSubset> Find()
		{
			return BaseFind();
		}

        public void Cancel(long? createdInvoiceGivenNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}

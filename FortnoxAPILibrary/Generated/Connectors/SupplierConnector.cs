using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierConnector : EntityConnector<Supplier, EntityCollection<SupplierSubset>, Sort.By.Supplier?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Supplier FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string City { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Email { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Name { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string OrganisationNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Phone1 { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Phone2 { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string SupplierNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ZipCode { get; set; }

		/// <remarks/>
		public SupplierConnector()
		{
			Resource = "suppliers";
		}

		/// <summary>
		/// Find a supplier based on suppliernumber
		/// </summary>
		/// <param name="supplierNumber">The suppliernumber to find</param>
		/// <returns>The found supplier</returns>
		public Supplier Get(string supplierNumber)
		{
			return BaseGet(supplierNumber);
		}

		/// <summary>
		/// Updates a supplier
		/// </summary>
		/// <param name="supplier">The supplier to update</param>
		/// <returns>The updated supplier</returns>
		public Supplier Update(Supplier supplier)
		{
			return BaseUpdate(supplier, supplier.SupplierNumber);
		}

		/// <summary>
		/// Create a new supplier
		/// </summary>
		/// <param name="supplier">The supplier to create</param>
		/// <returns>The created supplier</returns>
		public Supplier Create(Supplier supplier)
		{
			return BaseCreate(supplier);
		}

		/// <summary>
		/// Deletes a supplier
		/// </summary>
		/// <param name="supplierNumber">The suppliernumber to delete</param>
		public void Delete(string supplierNumber)
		{
			BaseDelete(supplierNumber);
		}

		/// <summary>
		/// Gets a list of suppliers
		/// </summary>
		/// <returns>A list of suppliers</returns>
		public EntityCollection<SupplierSubset> Find()
		{
			return BaseFind();
		}
	}
}

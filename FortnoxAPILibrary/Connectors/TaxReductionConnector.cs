using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TaxReductionConnector : EntityConnector<TaxReduction, EntityCollection<TaxReductionSubset>, Sort.By.TaxReduction?>
	{
		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string ReferenceNumber { get; set; }

        /// <remarks/>
        [FilterProperty("filter")]
		public Filter.Invoice? FilterBy { get; set; }

        /// <remarks/>
        public enum TypeOfReduction
		{
			/// <remarks/>
			ROT,
			/// <remarks/>
			RUT
		}

		/// <remarks/>
		public enum ReferenceDocumentType
		{
			/// <remarks/>
			OFFER,
			/// <remarks/>
			ORDER,
			/// <remarks/>
			INVOICE
		}

		/// <remarks/>
		public TaxReductionConnector()
		{
			Resource = "taxreductions";
		}

		/// <summary>
		/// Find a tax reduction based on id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public TaxReduction Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a tax reduction
		/// </summary>
		/// <param name="taxReduction">The tax reduction to update</param>
		/// <returns>The updated tax reduction</returns>
		public TaxReduction Update(TaxReduction taxReduction)
		{
			return BaseUpdate(taxReduction, taxReduction.Id);
		}

		/// <summary>
		/// Create a new tax reduction
		/// </summary>
		/// <param name="taxReduction">The tax reduction to create</param>
		/// <returns>The created tax reduction</returns>
		public TaxReduction Create(TaxReduction taxReduction)
		{
			return BaseCreate(taxReduction);
		}

		/// <summary>
		/// Deletes a tax reduction
		/// </summary>
		/// <param name="id">Id of the tax reduction to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of tax reductions
		/// </summary>
		/// <returns>A list of tax reductions</returns>
		public EntityCollection<TaxReductionSubset> Find()
		{
			return BaseFind();
		}
	}
}

using FortnoxAPILibrary;
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
        [SearchParameter("filter")]
		public Filter.TaxReduction? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ReferenceNumber { get; set; }

		/// <remarks/>
		public TaxReductionConnector()
		{
			Resource = "taxreductions";
		}

		/// <summary>
		/// Find a taxReduction based on id
		/// </summary>
		/// <param name="id">Identifier of the taxReduction to find</param>
		/// <returns>The found taxReduction</returns>
		public TaxReduction Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a taxReduction
		/// </summary>
		/// <param name="taxReduction">The taxReduction to update</param>
		/// <returns>The updated taxReduction</returns>
		public TaxReduction Update(TaxReduction taxReduction)
		{
			return BaseUpdate(taxReduction, taxReduction.Id.ToString());
		}

		/// <summary>
		/// Creates a new taxReduction
		/// </summary>
		/// <param name="taxReduction">The taxReduction to create</param>
		/// <returns>The created taxReduction</returns>
		public TaxReduction Create(TaxReduction taxReduction)
		{
			return BaseCreate(taxReduction);
		}

		/// <summary>
		/// Deletes a taxReduction
		/// </summary>
		/// <param name="id">Identifier of the taxReduction to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of taxReductions
		/// </summary>
		/// <returns>A list of taxReductions</returns>
		public EntityCollection<TaxReductionSubset> Find()
		{
			return BaseFind();
		}
	}
}

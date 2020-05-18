using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TaxReductionConnector : EntityConnector<TaxReduction, EntityCollection<TaxReductionSubset>, Sort.By.TaxReduction?>, ITaxReductionConnector
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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a taxReduction
		/// </summary>
		/// <param name="taxReduction">The taxReduction to update</param>
		/// <returns>The updated taxReduction</returns>
		public TaxReduction Update(TaxReduction taxReduction)
		{
			return UpdateAsync(taxReduction).Result;
		}

		/// <summary>
		/// Creates a new taxReduction
		/// </summary>
		/// <param name="taxReduction">The taxReduction to create</param>
		/// <returns>The created taxReduction</returns>
		public TaxReduction Create(TaxReduction taxReduction)
		{
			return CreateAsync(taxReduction).Result;
		}

		/// <summary>
		/// Deletes a taxReduction
		/// </summary>
		/// <param name="id">Identifier of the taxReduction to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of taxReductions
		/// </summary>
		/// <returns>A list of taxReductions</returns>
		public EntityCollection<TaxReductionSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<TaxReductionSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id);
		}
		public async Task<TaxReduction> CreateAsync(TaxReduction taxReduction)
		{
			return await BaseCreate(taxReduction);
		}
		public async Task<TaxReduction> UpdateAsync(TaxReduction taxReduction)
		{
			return await BaseUpdate(taxReduction, taxReduction.Id);
		}
		public async Task<TaxReduction> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}

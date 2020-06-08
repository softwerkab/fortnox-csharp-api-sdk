using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class FinancialYearConnector : EntityConnector<FinancialYear, EntityCollection<FinancialYearSubset>, Sort.By.FinancialYear?>, IFinancialYearConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.FinancialYear? FilterBy { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
        public string Date { get; set; }

		/// <remarks/>
		public FinancialYearConnector()
		{
			Resource = "financialyears";
		}
		/// <summary>
		/// Find a financialYear based on id
		/// </summary>
		/// <param name="id">Identifier of the financialYear to find</param>
		/// <returns>The found financialYear</returns>
		public FinancialYear Get(int? id)
		{
			return GetAsync(id).Result;
		}

        /// <summary>
		/// Creates a new financialYear
		/// </summary>
		/// <param name="financialYear">The financialYear to create</param>
		/// <returns>The created financialYear</returns>
		public FinancialYear Create(FinancialYear financialYear)
		{
			return CreateAsync(financialYear).Result;
		}

        /// <summary>
		/// Gets a list of financialYears
		/// </summary>
		/// <returns>A list of financialYears</returns>
		public EntityCollection<FinancialYearSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<FinancialYearSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task<FinancialYear> CreateAsync(FinancialYear financialYear)
		{
			return await BaseCreate(financialYear);
		}
		public async Task<FinancialYear> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
	}
}

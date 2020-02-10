using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class LockedPeriodConnector : EntityConnector<LockedPeriod, EntityCollection<LockedPeriodSubset>, Sort.By.LockedPeriod?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.LockedPeriod FilterBy { get; set; }


		/// <remarks/>
		public LockedPeriodConnector()
		{
			Resource = "lockedperiods";
		}

		/// <summary>
		/// Find a lockedPeriod based on lockedPeriodnumber
		/// </summary>
		/// <param name="lockedPeriodNumber">The lockedPeriodnumber to find</param>
		/// <returns>The found lockedPeriod</returns>
		public LockedPeriod Get(string lockedPeriodNumber)
		{
			return BaseGet(lockedPeriodNumber);
		}

		/// <summary>
		/// Updates a lockedPeriod
		/// </summary>
		/// <param name="lockedPeriod">The lockedPeriod to update</param>
		/// <returns>The updated lockedPeriod</returns>
		public LockedPeriod Update(LockedPeriod lockedPeriod)
		{
			return BaseUpdate(lockedPeriod, lockedPeriod.LockedPeriodNumber);
		}

		/// <summary>
		/// Create a new lockedPeriod
		/// </summary>
		/// <param name="lockedPeriod">The lockedPeriod to create</param>
		/// <returns>The created lockedPeriod</returns>
		public LockedPeriod Create(LockedPeriod lockedPeriod)
		{
			return BaseCreate(lockedPeriod);
		}

		/// <summary>
		/// Deletes a lockedPeriod
		/// </summary>
		/// <param name="lockedPeriodNumber">The lockedPeriodnumber to delete</param>
		public void Delete(string lockedPeriodNumber)
		{
			BaseDelete(lockedPeriodNumber);
		}

		/// <summary>
		/// Gets a list of lockedPeriods
		/// </summary>
		/// <returns>A list of lockedPeriods</returns>
		public EntityCollection<LockedPeriodSubset> Find()
		{
			return BaseFind();
		}
	}
}

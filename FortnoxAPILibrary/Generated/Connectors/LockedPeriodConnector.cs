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
		public Filter.LockedPeriod? FilterBy { get; set; }


		/// <remarks/>
		public LockedPeriodConnector()
		{
			Resource = "lockedperiods";
		}

		/// <summary>
		/// Find a lockedPeriod based on id
		/// </summary>
        /// <returns>The found lockedPeriod</returns>
		public LockedPeriod Get()
		{
			return BaseGet();
		}

		/// <summary>
		/// Updates a lockedPeriod
		/// </summary>
		/// <param name="lockedPeriod">The lockedPeriod to update</param>
		/// <returns>The updated lockedPeriod</returns>
		public LockedPeriod Update(LockedPeriod lockedPeriod)
		{
			return BaseUpdate(lockedPeriod, lockedPeriod.ToString());
		}

		/// <summary>
		/// Creates a new lockedPeriod
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
		/// <param name="id">Identifier of the lockedPeriod to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
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

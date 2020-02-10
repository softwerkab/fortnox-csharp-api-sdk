using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ScheduleTimesConnector : EntityConnector<ScheduleTimes, EntityCollection<ScheduleTimesSubset>, Sort.By.ScheduleTimes?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.ScheduleTimes? FilterBy { get; set; }


		/// <remarks/>
		public ScheduleTimesConnector()
		{
			Resource = "scheduletimes";
		}

		/// <summary>
		/// Find a scheduleTimes based on id
		/// </summary>
		/// <param name="id">Identifier of the scheduleTimes to find</param>
		/// <returns>The found scheduleTimes</returns>
		public ScheduleTimes Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a scheduleTimes
		/// </summary>
		/// <param name="scheduleTimes">The scheduleTimes to update</param>
		/// <returns>The updated scheduleTimes</returns>
		public ScheduleTimes Update(ScheduleTimes scheduleTimes)
		{
			return BaseUpdate(scheduleTimes, scheduleTimes.Id.ToString());
		}

		/// <summary>
		/// Creates a new scheduleTimes
		/// </summary>
		/// <param name="scheduleTimes">The scheduleTimes to create</param>
		/// <returns>The created scheduleTimes</returns>
		public ScheduleTimes Create(ScheduleTimes scheduleTimes)
		{
			return BaseCreate(scheduleTimes);
		}

		/// <summary>
		/// Deletes a scheduleTimes
		/// </summary>
		/// <param name="id">Identifier of the scheduleTimes to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of scheduleTimess
		/// </summary>
		/// <returns>A list of scheduleTimess</returns>
		public EntityCollection<ScheduleTimesSubset> Find()
		{
			return BaseFind();
		}
	}
}

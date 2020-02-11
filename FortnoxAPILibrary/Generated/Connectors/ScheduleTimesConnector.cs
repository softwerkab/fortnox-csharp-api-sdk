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
		/// Gets a list of scheduleTimess
		/// </summary>
		/// <returns>A list of scheduleTimess</returns>
		public EntityCollection<ScheduleTimesSubset> Find()
		{
			return BaseFind();
		}
	}
}

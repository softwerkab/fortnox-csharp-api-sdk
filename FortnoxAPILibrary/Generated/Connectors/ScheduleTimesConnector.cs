using System;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ScheduleTimesConnector : EntityConnector<ScheduleTimes, EntityCollection<ScheduleTimes>, Sort.By.ScheduleTimes?>, IScheduleTimesConnector
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
		public EntityCollection<ScheduleTimes> Find()
		{
			return BaseFind();
		}

		/// <summary>
		/// Gets a schedule time
		/// </summary>
		/// <param name="employeeId"></param>
		/// <param name="date"></param>
		/// <returns>The found schedule time</returns>
		public ScheduleTimes Get(string employeeId, DateTime? date)
        {
            return BaseGet(employeeId, date?.ToString(APIConstants.DateFormat));
        }

        public ScheduleTimes Update(ScheduleTimes scheduleTime)
        {
            return BaseUpdate(scheduleTime,scheduleTime.EmployeeId, scheduleTime.Date?.ToString(APIConstants.DateFormat));
        }

		/// <summary>
		/// Resets schedule time of a day according to the schedule that is assigned to the employee through the employment information
		/// </summary>
		/// <param name="employeeId"></param>
		/// <param name="date"></param>
		/// <returns>The reset schedule time</returns>
		public ScheduleTimes Reset(string employeeId, DateTime? date)
        {
            return BaseUpdate(null, employeeId, date?.ToString(APIConstants.DateFormat), "resetday");
        }
	}
}

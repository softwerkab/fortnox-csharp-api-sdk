using System;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ScheduleTimesConnector : SearchableEntityConnector<ScheduleTimes, ScheduleTimes, ScheduleTimesSearch>, IScheduleTimesConnector
	{

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
			return FindAsync().GetResult();
		}

		/// <summary>
		/// Gets a schedule time
		/// </summary>
		/// <param name="employeeId"></param>
		/// <param name="date"></param>
		/// <returns>The found schedule time</returns>
		public ScheduleTimes Get(string employeeId, DateTime? date)
        {
			return GetAsync(employeeId, date).GetResult();
        }

        public ScheduleTimes Update(ScheduleTimes scheduleTime)
        {
			return UpdateAsync(scheduleTime).GetResult();
        }

		/// <summary>
		/// Resets schedule time of a day according to the schedule that is assigned to the employee through the employment information
		/// </summary>
		/// <param name="employeeId"></param>
		/// <param name="date"></param>
		/// <returns>The reset schedule time</returns>
		public ScheduleTimes Reset(string employeeId, DateTime? date)
        {
			return ResetAsync(employeeId, date).GetResult();
        }

        public async Task<ScheduleTimes> ResetAsync(string employeeId, DateTime? date)
        {
            return await BaseUpdate(null, employeeId, date?.ToString(APIConstants.DateFormat), "resetday").ConfigureAwait(false);
        }
        public async Task<ScheduleTimes> UpdateAsync(ScheduleTimes scheduleTime)
        {
            return await BaseUpdate(scheduleTime,scheduleTime.EmployeeId, scheduleTime.Date?.ToString(APIConstants.DateFormat)).ConfigureAwait(false);
        }
		public async Task<ScheduleTimes> GetAsync(string employeeId, DateTime? date)
        {
            return await BaseGet(employeeId, date?.ToString(APIConstants.DateFormat)).ConfigureAwait(false);
        }
		public async Task<EntityCollection<ScheduleTimes>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
	}
}

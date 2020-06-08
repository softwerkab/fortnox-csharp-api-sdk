using System;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AttendanceTransactionsConnector : EntityConnector<AttendanceTransaction, EntityCollection<AttendanceTransactionSubset>, Sort.By.AttendanceTransactions?>, IAttendanceTransactionsConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.AttendanceTransactions? FilterBy { get; set; }

        [SearchParameter("employeeid")]
        public string EmployeeId { get; set; }

        [SearchParameter("date")]
        public DateTime? Date { get; set; }

        /// <remarks/>
        public AttendanceTransactionsConnector()
		{
			Resource = "attendancetransactions";
		}

        /// <summary>
        /// Gets a attendenceTransaction
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="date"></param>
        /// <param name="code"></param>
        /// <returns>The found attendanceTransaction</returns>
        public AttendanceTransaction Get(string employeeId, DateTime? date, AttendanceCauseCode? code)
        {
			return GetAsync(employeeId, date, code).Result;
        }

        /// <summary>
        /// Updates a attendanceTransaction
        /// </summary>
        /// <param name="attendanceTransaction">The attendanceTransaction to update</param>
        /// <returns>The updated attendanceTransaction</returns>
        public AttendanceTransaction Update(AttendanceTransaction attendanceTransaction)
        {
			return UpdateAsync(attendanceTransaction).Result;
        }

        /// <summary>
        /// Creates a new attendanceTransaction
        /// </summary>
        /// <param name="attendanceTransaction">The attendanceTransaction to create</param>
        /// <returns>The created attendanceTransaction</returns>
        public AttendanceTransaction Create(AttendanceTransaction attendanceTransaction)
        {
			return CreateAsync(attendanceTransaction).Result;
        }

        /// <summary>
        /// Deletes a attendanceTransaction
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="date"></param>
        /// <param name="code"></param>
        public void Delete(string employeeId, DateTime? date, AttendanceCauseCode? code)
        {
			DeleteAsync(employeeId, date, code).Wait();
        }

        /// <summary>
        /// Gets a list of attendanceTransactions
        /// </summary>
        /// <returns>A list of attendanceTransactions</returns>
        public EntityCollection<AttendanceTransactionSubset> Find()
        {
			return FindAsync().Result;
        }

        public async Task<EntityCollection<AttendanceTransactionSubset>> FindAsync()
        {
            return await BaseFind();
        }
        public async Task DeleteAsync(string employeeId, DateTime? date, AttendanceCauseCode? code)
        {
            await BaseDelete(employeeId, date?.ToString(APIConstants.DateFormat), code?.GetStringValue());
        }
        public async Task<AttendanceTransaction> CreateAsync(AttendanceTransaction attendanceTransaction)
        {
            return await BaseCreate(attendanceTransaction);
        }
        public async Task<AttendanceTransaction> UpdateAsync(AttendanceTransaction attendanceTransaction)
        {
            return await BaseUpdate(attendanceTransaction, attendanceTransaction.EmployeeId, attendanceTransaction.Date?.ToString(APIConstants.DateFormat), attendanceTransaction.CauseCode?.GetStringValue());
        }
        public async Task<AttendanceTransaction> GetAsync(string employeeId, DateTime? date, AttendanceCauseCode? code)
        {
            return await BaseGet(employeeId, date?.ToString(APIConstants.DateFormat), code?.GetStringValue());
        }
	}
}

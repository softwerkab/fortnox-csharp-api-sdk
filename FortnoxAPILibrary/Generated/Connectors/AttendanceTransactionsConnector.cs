using System;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AttendanceTransactionsConnector : EntityConnector<AttendanceTransaction, EntityCollection<AttendanceTransactionSubset>, Sort.By.AttendanceTransactions?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.AttendanceTransactions? FilterBy { get; set; }


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
            return BaseGet(employeeId, date?.ToString(APIConstants.DateFormat), code?.GetStringValue());
        }

        /// <summary>
        /// Updates a attendanceTransaction
        /// </summary>
        /// <param name="attendanceTransaction">The attendanceTransaction to update</param>
        /// <returns>The updated attendanceTransaction</returns>
        public AttendanceTransaction Update(AttendanceTransaction attendanceTransaction)
        {
            return BaseUpdate(attendanceTransaction, attendanceTransaction.EmployeeId, attendanceTransaction.Date?.ToString(APIConstants.DateFormat), attendanceTransaction.CauseCode?.GetStringValue());
        }

        /// <summary>
        /// Creates a new attendanceTransaction
        /// </summary>
        /// <param name="attendanceTransaction">The attendanceTransaction to create</param>
        /// <returns>The created attendanceTransaction</returns>
        public AttendanceTransaction Create(AttendanceTransaction attendanceTransaction)
        {
            return BaseCreate(attendanceTransaction);
        }

        /// <summary>
        /// Deletes a attendanceTransaction
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="date"></param>
        /// <param name="code"></param>
        public void Delete(string employeeId, DateTime? date, AttendanceCauseCode? code)
        {
            BaseDelete(employeeId, date?.ToString(APIConstants.DateFormat), code?.GetStringValue());
        }

        /// <summary>
        /// Gets a list of attendanceTransactions
        /// </summary>
        /// <returns>A list of attendanceTransactions</returns>
        public EntityCollection<AttendanceTransactionSubset> Find()
        {
            return BaseFind();
        }
	}
}

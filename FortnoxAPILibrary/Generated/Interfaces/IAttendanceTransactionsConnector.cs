using System;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAttendanceTransactionsConnector
	{
        [SearchParameter("filter")]
		Filter.AttendanceTransactions? FilterBy { get; set; }

		AttendanceTransaction Update(AttendanceTransaction attendanceTransaction);

		AttendanceTransaction Create(AttendanceTransaction attendanceTransaction);

		AttendanceTransaction Get(string employeeId, DateTime? date, AttendanceCauseCode? code);

		void Delete(string employeeId, DateTime? date, AttendanceCauseCode? code);

		EntityCollection<AttendanceTransactionSubset> Find();

	}
}

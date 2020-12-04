using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IAttendanceTransactionsConnector : IEntityConnector
	{

		AttendanceTransaction Update(AttendanceTransaction attendanceTransaction);
		AttendanceTransaction Create(AttendanceTransaction attendanceTransaction);
		AttendanceTransaction Get(string employeeId, DateTime? date, AttendanceCauseCode? code);
		void Delete(string employeeId, DateTime? date, AttendanceCauseCode? code);
		EntityCollection<AttendanceTransactionSubset> Find(AttendanceTransactionsSearch searchSettings);

		Task<AttendanceTransaction> UpdateAsync(AttendanceTransaction attendanceTransaction);
		Task<AttendanceTransaction> CreateAsync(AttendanceTransaction attendanceTransaction);
		Task<AttendanceTransaction> GetAsync(string employeeId, DateTime? date, AttendanceCauseCode? code);
		Task DeleteAsync(string employeeId, DateTime? date, AttendanceCauseCode? code);
		Task<EntityCollection<AttendanceTransactionSubset>> FindAsync(AttendanceTransactionsSearch searchSettings);
	}
}

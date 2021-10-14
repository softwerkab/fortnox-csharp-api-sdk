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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        AttendanceTransaction Update(AttendanceTransaction attendanceTransaction);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        AttendanceTransaction Create(AttendanceTransaction attendanceTransaction);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        AttendanceTransaction Get(string employeeId, DateTime? date, AttendanceCauseCode? code);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(string employeeId, DateTime? date, AttendanceCauseCode? code);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<AttendanceTransactionSubset> Find(AttendanceTransactionsSearch searchSettings);

        Task<AttendanceTransaction> UpdateAsync(AttendanceTransaction attendanceTransaction);
        Task<AttendanceTransaction> CreateAsync(AttendanceTransaction attendanceTransaction);
        Task<AttendanceTransaction> GetAsync(string employeeId, DateTime? date, AttendanceCauseCode? code);
        Task DeleteAsync(string employeeId, DateTime? date, AttendanceCauseCode? code);
        Task<EntityCollection<AttendanceTransactionSubset>> FindAsync(AttendanceTransactionsSearch searchSettings);
    }
}

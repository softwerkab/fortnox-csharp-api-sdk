using System;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class AttendanceTransactionsConnector : SearchableEntityConnector<AttendanceTransaction, AttendanceTransactionSubset, AttendanceTransactionsSearch>, IAttendanceTransactionsConnector
{
    public AttendanceTransactionsConnector()
    {
        Resource = Endpoints.AttendanceTransactions;
    }

    public AttendanceTransaction Get(string employeeId, DateTime? date, AttendanceCauseCode? code)
    {
        return GetAsync(employeeId, date, code).GetResult();
    }

    public AttendanceTransaction Update(AttendanceTransaction attendanceTransaction)
    {
        return UpdateAsync(attendanceTransaction).GetResult();
    }

    public AttendanceTransaction Create(AttendanceTransaction attendanceTransaction)
    {
        return CreateAsync(attendanceTransaction).GetResult();
    }

    public void Delete(string employeeId, DateTime? date, AttendanceCauseCode? code)
    {
        DeleteAsync(employeeId, date, code).GetResult();
    }

    public EntityCollection<AttendanceTransactionSubset> Find(AttendanceTransactionsSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<AttendanceTransactionSubset>> FindAsync(AttendanceTransactionsSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string employeeId, DateTime? date, AttendanceCauseCode? code)
    {
        await BaseDelete(employeeId, date?.ToString(ApiConstants.DateFormat), code?.GetStringValue()).ConfigureAwait(false);
    }

    public async Task<AttendanceTransaction> CreateAsync(AttendanceTransaction attendanceTransaction)
    {
        return await BaseCreate(attendanceTransaction).ConfigureAwait(false);
    }

    public async Task<AttendanceTransaction> UpdateAsync(AttendanceTransaction attendanceTransaction)
    {
        return await BaseUpdate(attendanceTransaction, attendanceTransaction.EmployeeId, attendanceTransaction.Date?.ToString(ApiConstants.DateFormat), attendanceTransaction.CauseCode?.GetStringValue()).ConfigureAwait(false);
    }

    public async Task<AttendanceTransaction> GetAsync(string employeeId, DateTime? date, AttendanceCauseCode? code)
    {
        return await BaseGet(employeeId, date?.ToString(ApiConstants.DateFormat), code?.GetStringValue()).ConfigureAwait(false);
    }
}
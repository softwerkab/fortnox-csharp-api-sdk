using System;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class AttendanceTransactionsConnector : SearchableEntityConnector<AttendanceTransaction, AttendanceTransaction, AttendanceTransactionsSearch>, IAttendanceTransactionsConnector
{
    public AttendanceTransactionsConnector()
    {
        Endpoint = Endpoints.AttendanceTransactions;
    }

    public async Task<EntityCollection<AttendanceTransaction>> FindAsync(AttendanceTransactionsSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<AttendanceTransaction> CreateAsync(AttendanceTransaction attendanceTransaction)
    {
        return await BaseCreate(attendanceTransaction).ConfigureAwait(false);
    }

    public async Task<AttendanceTransaction> UpdateAsync(AttendanceTransaction attendanceTransaction)
    {
        return await BaseUpdate(attendanceTransaction, attendanceTransaction.Id).ConfigureAwait(false);
    }

    public async Task<AttendanceTransaction> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}
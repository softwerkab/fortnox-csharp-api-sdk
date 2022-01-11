using System;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class AbsenceTransactionConnector : SearchableEntityConnector<AbsenceTransaction, AbsenceTransaction, AbsenceTransactionSearch>, IAbsenceTransactionConnector
{
    public AbsenceTransactionConnector()
    {
        Endpoint = Endpoints.AbsenceTransactions;
    }

    public async Task<EntityCollection<AbsenceTransaction>> FindAsync(AbsenceTransactionSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string employeeId, DateTime? date, AbsenceCauseCode? code)
    {
        await BaseDelete(employeeId, date?.ToString(ApiConstants.DateFormat), code?.GetStringValue()).ConfigureAwait(false);
    }

    public async Task<AbsenceTransaction> CreateAsync(AbsenceTransaction absenceTransaction)
    {
        return await BaseCreate(absenceTransaction).ConfigureAwait(false);
    }

    public async Task<AbsenceTransaction> UpdateAsync(AbsenceTransaction absenceTransaction)
    {
        return await BaseUpdate(absenceTransaction, absenceTransaction.EmployeeId, absenceTransaction.Date?.ToString(ApiConstants.DateFormat), absenceTransaction.CauseCode?.GetStringValue()).ConfigureAwait(false);
    }

    public async Task<AbsenceTransaction> GetAsync(string employeeId, DateTime? date, AbsenceCauseCode? code)
    {
        return await BaseGet(employeeId, date?.ToString(ApiConstants.DateFormat), code?.GetStringValue()).ConfigureAwait(false);
    }
}
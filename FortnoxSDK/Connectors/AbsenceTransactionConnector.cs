using System;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors;

/// <remarks/>
internal class AbsenceTransactionConnector : SearchableEntityConnector<AbsenceTransaction, AbsenceTransaction, AbsenceTransactionSearch>, IAbsenceTransactionConnector
{


    /// <remarks/>
    public AbsenceTransactionConnector()
    {
        Resource = "absencetransactions";
    }

    /// <summary>
    /// Gets a absenceTransaction
    /// </summary>
    /// <param name="employeeId"></param>
    /// <param name="date"></param>
    /// <param name="code"></param>
    /// <returns>The found absenceTransaction</returns>
    public AbsenceTransaction Get(string employeeId, DateTime? date, AbsenceCauseCode? code)
    {
        return GetAsync(employeeId, date, code).GetResult();
    }

    /// <summary>
    /// Updates a absenceTransaction
    /// </summary>
    /// <param name="absenceTransaction">The absenceTransaction to update</param>
    /// <returns>The updated absenceTransaction</returns>
    public AbsenceTransaction Update(AbsenceTransaction absenceTransaction)
    {
        return UpdateAsync(absenceTransaction).GetResult();
    }

    /// <summary>
    /// Creates a new absenceTransaction
    /// </summary>
    /// <param name="absenceTransaction">The absenceTransaction to create</param>
    /// <returns>The created absenceTransaction</returns>
    public AbsenceTransaction Create(AbsenceTransaction absenceTransaction)
    {
        return CreateAsync(absenceTransaction).GetResult();
    }

    /// <summary>
    /// Deletes a absenceTransaction
    /// </summary>
    /// <param name="employeeId"></param>
    /// <param name="date"></param>
    /// <param name="code"></param>
    public void Delete(string employeeId, DateTime? date, AbsenceCauseCode? code)
    {
        DeleteAsync(employeeId, date, code).GetResult();
    }

    /// <summary>
    /// Gets a list of absenceTransactions
    /// </summary>
    /// <returns>A list of absenceTransactions</returns>
    public EntityCollection<AbsenceTransaction> Find(AbsenceTransactionSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
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
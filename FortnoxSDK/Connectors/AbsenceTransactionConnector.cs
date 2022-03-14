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

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<AbsenceTransaction> CreateAsync(AbsenceTransaction absenceTransaction)
    {
        return await BaseCreate(absenceTransaction).ConfigureAwait(false);
    }

    public async Task<AbsenceTransaction> UpdateAsync(AbsenceTransaction absenceTransaction)
    {
        return await BaseUpdate(absenceTransaction, absenceTransaction.Id).ConfigureAwait(false);
    }

    public async Task<AbsenceTransaction> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}
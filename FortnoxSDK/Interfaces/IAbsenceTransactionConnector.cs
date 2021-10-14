using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IAbsenceTransactionConnector : IEntityConnector
	{
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		AbsenceTransaction Update(AbsenceTransaction absenceTransaction);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		AbsenceTransaction Create(AbsenceTransaction absenceTransaction);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		AbsenceTransaction Get(string employeeId, DateTime? date, AbsenceCauseCode? code);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		void Delete(string employeeId, DateTime? date, AbsenceCauseCode? code);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<AbsenceTransaction> Find(AbsenceTransactionSearch searchSettings);

		Task<AbsenceTransaction> UpdateAsync(AbsenceTransaction absenceTransaction);
		Task<AbsenceTransaction> CreateAsync(AbsenceTransaction absenceTransaction);
		Task<AbsenceTransaction> GetAsync(string employeeId, DateTime? date, AbsenceCauseCode? code);
		Task DeleteAsync(string employeeId, DateTime? date, AbsenceCauseCode? code);
		Task<EntityCollection<AbsenceTransaction>> FindAsync(AbsenceTransactionSearch searchSettings);
	}
}

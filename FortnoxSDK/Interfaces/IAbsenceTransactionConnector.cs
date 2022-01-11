using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IAbsenceTransactionConnector : IEntityConnector
{
    Task<AbsenceTransaction> UpdateAsync(AbsenceTransaction absenceTransaction);
    Task<AbsenceTransaction> CreateAsync(AbsenceTransaction absenceTransaction);
    Task<AbsenceTransaction> GetAsync(string employeeId, DateTime? date, AbsenceCauseCode? code);
    Task DeleteAsync(string employeeId, DateTime? date, AbsenceCauseCode? code);
    Task<EntityCollection<AbsenceTransaction>> FindAsync(AbsenceTransactionSearch searchSettings);
}
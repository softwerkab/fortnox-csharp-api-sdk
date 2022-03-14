using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IAttendanceTransactionsConnector : IEntityConnector
{
    Task<AttendanceTransaction> UpdateAsync(AttendanceTransaction attendanceTransaction);
    Task<AttendanceTransaction> CreateAsync(AttendanceTransaction attendanceTransaction);
    Task<AttendanceTransaction> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<AttendanceTransaction>> FindAsync(AttendanceTransactionsSearch searchSettings);
}
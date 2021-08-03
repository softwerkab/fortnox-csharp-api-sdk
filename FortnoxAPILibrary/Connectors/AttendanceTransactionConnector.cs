using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Connectors
{
    /// <summary>
    /// Connector to attendanceTransactions endpoint
    /// </summary>
    public interface IAttendanceTransactionConnector : IEntityConnector<Sort.By.AttendanceTransaction>
    {
        /// <remarks/>
        Filter.AttendanceTransaction FilterBy { get; set; }

        /// <summary>
        /// Find an attendanceTransaction based on attendanceTransactionId
        /// </summary>
        /// <returns>The found attendanceTransaction</returns>
        AttendanceTransaction Get(string employeeId, string date, AttendanceCauseCode code);

        /// <summary>
        /// Updates an attendanceTransaction
        /// </summary>
        /// <param name="attendanceTransaction">The attendanceTransaction to update</param>
        /// <returns>The updated attendanceTransaction</returns>
        AttendanceTransaction Update(AttendanceTransaction attendanceTransaction);

        /// <summary>
        /// Create a new attendanceTransaction
        /// </summary>
        /// <param name="attendanceTransaction">The attendanceTransaction to create</param>
        /// <returns>The created attendanceTransaction</returns>
        AttendanceTransaction Create(AttendanceTransaction attendanceTransaction);

        /// <summary>
        /// Gets a list of attendanceTransactions
        /// </summary>
        /// <returns>A list of attendanceTransactions</returns>
        AttendanceTransactions Find(string employeeId = null, string date = null);
    }

    /// <summary>
    /// Connector to attendanceTransactions endpoint
    /// </summary>
    public class AttendanceTransactionConnector : EntityConnector<AttendanceTransaction, AttendanceTransactions, Sort.By.AttendanceTransaction>, IAttendanceTransactionConnector
    {
        /// <summary>
        /// Implementation of connector to attendanceTransactions endpoint
        /// </summary>
        public AttendanceTransactionConnector()
        {
            Resource = "attendancetransactions";
        }

        /// <inheritdoc />
        public Filter.AttendanceTransaction FilterBy { get; set; }

        /// <inheritdoc />
        public AttendanceTransaction Get(string employeeId, string date, AttendanceCauseCode code)
        {
            return BaseGet(employeeId, date, code.GetStringValue());
        }

        /// <inheritdoc />
        public AttendanceTransaction Update(AttendanceTransaction attendanceTransaction)
        {
            if (string.IsNullOrEmpty(attendanceTransaction.EmployeeId))
                throw new ArgumentException("AttendanceTransaction must have an EmployeeId to be able to update", nameof(attendanceTransaction.EmployeeId));
            if (string.IsNullOrEmpty(attendanceTransaction.Date))
                throw new ArgumentException("AttendanceTransaction must have an Date to be able to update", nameof(attendanceTransaction.Date));

            var code = attendanceTransaction.CauseCode.GetStringValue();
            return BaseUpdate(attendanceTransaction, attendanceTransaction.EmployeeId, attendanceTransaction.Date, code);
        }

        /// <inheritdoc />
        public AttendanceTransaction Create(AttendanceTransaction attendanceTransaction)
        {
            return BaseCreate(attendanceTransaction);
        }

        /// <inheritdoc />
        public AttendanceTransactions Find(string employeeId = null, string date = null)
        {
            Parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(employeeId))
            {
                Parameters.Add("employeeid", employeeId);
            }

            if (!string.IsNullOrEmpty(date))
            {
                Parameters.Add("date", date);
            }

            return BaseFind();
        }
    }
}
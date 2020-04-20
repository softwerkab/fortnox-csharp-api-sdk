using System;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AbsenceTransactionConnector : EntityConnector<AbsenceTransaction, EntityCollection<AbsenceTransaction>, Sort.By.AbsenceTransaction?>, IAbsenceTransactionConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.AbsenceTransaction? FilterBy { get; set; }


		[SearchParameter("employeeid")]
		public string EmployeeId { get; set; }

        [SearchParameter("date")]
        public DateTime? Date { get; set; }

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
			return BaseGet(employeeId, date?.ToString(APIConstants.DateFormat), code?.GetStringValue());
		}

		/// <summary>
		/// Updates a absenceTransaction
		/// </summary>
		/// <param name="absenceTransaction">The absenceTransaction to update</param>
		/// <returns>The updated absenceTransaction</returns>
		public AbsenceTransaction Update(AbsenceTransaction absenceTransaction)
		{
			return BaseUpdate(absenceTransaction, absenceTransaction.EmployeeId, absenceTransaction.Date?.ToString(APIConstants.DateFormat), absenceTransaction.CauseCode?.GetStringValue());
		}

		/// <summary>
		/// Creates a new absenceTransaction
		/// </summary>
		/// <param name="absenceTransaction">The absenceTransaction to create</param>
		/// <returns>The created absenceTransaction</returns>
		public AbsenceTransaction Create(AbsenceTransaction absenceTransaction)
		{
			return BaseCreate(absenceTransaction);
		}

		/// <summary>
		/// Deletes a absenceTransaction
		/// </summary>
        /// <param name="employeeId"></param>
        /// <param name="date"></param>
        /// <param name="code"></param>
		public void Delete(string employeeId, DateTime? date, AbsenceCauseCode? code)
		{
			BaseDelete(employeeId, date?.ToString(APIConstants.DateFormat), code?.GetStringValue());
		}

		/// <summary>
		/// Gets a list of absenceTransactions
		/// </summary>
		/// <returns>A list of absenceTransactions</returns>
		public EntityCollection<AbsenceTransaction> Find()
		{
			return BaseFind();
		}
	}
}

using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AttendanceTransactionsConnector : EntityConnector<AttendanceTransactions, EntityCollection<AttendanceTransactionsSubset>, Sort.By.AttendanceTransactions?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.AttendanceTransactions? FilterBy { get; set; }


		/// <remarks/>
		public AttendanceTransactionsConnector()
		{
			Resource = "attendancetransactions";
		}

		/// <summary>
		/// Find a attendanceTransactions based on id
		/// </summary>
		/// <param name="id">Identifier of the attendanceTransactions to find</param>
		/// <returns>The found attendanceTransactions</returns>
		public AttendanceTransactions Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a attendanceTransactions
		/// </summary>
		/// <param name="attendanceTransactions">The attendanceTransactions to update</param>
		/// <returns>The updated attendanceTransactions</returns>
		public AttendanceTransactions Update(AttendanceTransactions attendanceTransactions)
		{
			return BaseUpdate(attendanceTransactions, attendanceTransactions.Id.ToString());
		}

		/// <summary>
		/// Creates a new attendanceTransactions
		/// </summary>
		/// <param name="attendanceTransactions">The attendanceTransactions to create</param>
		/// <returns>The created attendanceTransactions</returns>
		public AttendanceTransactions Create(AttendanceTransactions attendanceTransactions)
		{
			return BaseCreate(attendanceTransactions);
		}

		/// <summary>
		/// Deletes a attendanceTransactions
		/// </summary>
		/// <param name="id">Identifier of the attendanceTransactions to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of attendanceTransactionss
		/// </summary>
		/// <returns>A list of attendanceTransactionss</returns>
		public EntityCollection<AttendanceTransactionsSubset> Find()
		{
			return BaseFind();
		}
	}
}

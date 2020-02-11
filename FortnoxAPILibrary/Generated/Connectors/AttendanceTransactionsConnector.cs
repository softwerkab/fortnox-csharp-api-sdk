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
		/// Gets a list of attendanceTransactionss
		/// </summary>
		/// <returns>A list of attendanceTransactionss</returns>
		public EntityCollection<AttendanceTransactionsSubset> Find()
		{
			return BaseFind();
		}
	}
}

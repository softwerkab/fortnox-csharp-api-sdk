using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AbsenceTransactionConnector : EntityConnector<AbsenceTransaction, EntityCollection<AbsenceTransactionSubset>, Sort.By.AbsenceTransaction?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.AbsenceTransaction? FilterBy { get; set; }


		/// <remarks/>
		public AbsenceTransactionConnector()
		{
			Resource = "absencetransactions";
		}
		/// <summary>
		/// Gets a list of absenceTransactions
		/// </summary>
		/// <returns>A list of absenceTransactions</returns>
		public EntityCollection<AbsenceTransactionSubset> Find()
		{
			return BaseFind();
		}
	}
}

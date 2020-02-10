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
		/// Find a absenceTransaction based on id
		/// </summary>
		/// <param name="id">Identifier of the absenceTransaction to find</param>
		/// <returns>The found absenceTransaction</returns>
		public AbsenceTransaction Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a absenceTransaction
		/// </summary>
		/// <param name="absenceTransaction">The absenceTransaction to update</param>
		/// <returns>The updated absenceTransaction</returns>
		public AbsenceTransaction Update(AbsenceTransaction absenceTransaction)
		{
			return BaseUpdate(absenceTransaction, absenceTransaction.Id.ToString());
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
		/// <param name="id">Identifier of the absenceTransaction to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
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

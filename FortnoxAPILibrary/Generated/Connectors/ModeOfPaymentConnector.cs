using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ModeOfPaymentConnector : EntityConnector<ModeOfPayment, EntityCollection<ModeOfPaymentSubset>, Sort.By.ModeOfPayment?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.ModeOfPayment? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Code { get; set; }

		/// <remarks/>
		public ModeOfPaymentConnector()
		{
			Resource = "modeofpayments";
		}

		/// <summary>
		/// Find a modeOfPayment based on id
		/// </summary>
		/// <param name="id">Identifier of the modeOfPayment to find</param>
		/// <returns>The found modeOfPayment</returns>
		public ModeOfPayment Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a modeOfPayment
		/// </summary>
		/// <param name="modeOfPayment">The modeOfPayment to update</param>
		/// <returns>The updated modeOfPayment</returns>
		public ModeOfPayment Update(ModeOfPayment modeOfPayment)
		{
			return BaseUpdate(modeOfPayment, modeOfPayment.Code.ToString());
		}

		/// <summary>
		/// Creates a new modeOfPayment
		/// </summary>
		/// <param name="modeOfPayment">The modeOfPayment to create</param>
		/// <returns>The created modeOfPayment</returns>
		public ModeOfPayment Create(ModeOfPayment modeOfPayment)
		{
			return BaseCreate(modeOfPayment);
		}

		/// <summary>
		/// Deletes a modeOfPayment
		/// </summary>
		/// <param name="id">Identifier of the modeOfPayment to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of modeOfPayments
		/// </summary>
		/// <returns>A list of modeOfPayments</returns>
		public EntityCollection<ModeOfPaymentSubset> Find()
		{
			return BaseFind();
		}
	}
}

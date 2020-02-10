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
		public Filter.ModeOfPayment FilterBy { get; set; }


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
		/// Find a modeOfPayment based on modeOfPaymentnumber
		/// </summary>
		/// <param name="modeOfPaymentNumber">The modeOfPaymentnumber to find</param>
		/// <returns>The found modeOfPayment</returns>
		public ModeOfPayment Get(string modeOfPaymentNumber)
		{
			return BaseGet(modeOfPaymentNumber);
		}

		/// <summary>
		/// Updates a modeOfPayment
		/// </summary>
		/// <param name="modeOfPayment">The modeOfPayment to update</param>
		/// <returns>The updated modeOfPayment</returns>
		public ModeOfPayment Update(ModeOfPayment modeOfPayment)
		{
			return BaseUpdate(modeOfPayment, modeOfPayment.ModeOfPaymentNumber);
		}

		/// <summary>
		/// Create a new modeOfPayment
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
		/// <param name="modeOfPaymentNumber">The modeOfPaymentnumber to delete</param>
		public void Delete(string modeOfPaymentNumber)
		{
			BaseDelete(modeOfPaymentNumber);
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

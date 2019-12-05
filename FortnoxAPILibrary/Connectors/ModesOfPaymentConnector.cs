using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ModesOfPaymentConnector : FinancialYearBasedEntityConnector<ModeOfPayment, ModesOfPayments, Sort.By.ModesOfPayment>
	{
		/// <remarks/>
		public ModesOfPaymentConnector()
		{
			Resource = "modesofpayments";
		}

		/// <summary>
		/// Find a mode of payment 
		/// </summary>
		/// <param name="code">The code to find</param>
		/// <returns>The found mode of payment</returns>
		public ModeOfPayment Get(string code)
		{
			return BaseGet(code);
		}

		/// <summary>
		/// Updates a mode of payment
		/// </summary>
		/// <param name="modeofpayment">The mode of payment to update</param>
		/// <returns>The updated mode of payment</returns>
		public ModeOfPayment Update(ModeOfPayment modeofpayment)
		{
			return BaseUpdate(modeofpayment, modeofpayment.Code);
		}

		/// <summary>
		/// Create a new Mode of payment
		/// </summary>
		/// <param name="modeOfPayment">The mode of payment to create</param>
		/// <returns>The created mode of payment</returns>
		public ModeOfPayment Create(ModeOfPayment modeOfPayment)
		{
			return BaseCreate(modeOfPayment);
		}

		/// <summary>
		/// Deletes a mode of payment
		/// </summary>
		/// <param name="code">The code of the mode of payment to delete</param>
		public void Delete(string code)
		{
			BaseDelete(code);
		}

		/// <summary>
		/// Gets a list of Modes of payment
		/// </summary>
		/// <returns></returns>
		public ModesOfPayments Find()
		{
			return BaseFind();
		}
	}
}
